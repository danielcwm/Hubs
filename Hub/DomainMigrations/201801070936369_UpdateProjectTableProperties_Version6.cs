namespace Hub.DomainMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProjectTableProperties_Version6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "CreatorId", "dbo.DomainUsers");
            DropIndex("dbo.Projects", new[] { "CreatorId" });
            DropColumn("dbo.DomainUsers", "ProjectId");
            DropColumn("dbo.Projects", "CreatorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "CreatorId", c => c.Int(nullable: false));
            AddColumn("dbo.DomainUsers", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "CreatorId");
            AddForeignKey("dbo.Projects", "CreatorId", "dbo.DomainUsers", "Id", cascadeDelete: true);
        }
    }
}
