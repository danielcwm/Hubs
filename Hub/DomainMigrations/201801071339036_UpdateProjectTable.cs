namespace Hub.DomainMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProjectTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Tags_Id", c => c.Int());
            CreateIndex("dbo.Projects", "Tags_Id");
            AddForeignKey("dbo.Projects", "Tags_Id", "dbo.Tags", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Tags_Id", "dbo.Tags");
            DropIndex("dbo.Projects", new[] { "Tags_Id" });
            DropColumn("dbo.Projects", "Tags_Id");
        }
    }
}
