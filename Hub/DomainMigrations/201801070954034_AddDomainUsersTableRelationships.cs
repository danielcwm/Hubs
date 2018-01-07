namespace Hub.DomainMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDomainUsersTableRelationships : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UniversityStudent",
                c => new
                    {
                        UniversityId = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UniversityId, t.UserId })
                .ForeignKey("dbo.DomainUsers", t => t.UniversityId, cascadeDelete: true)
                .ForeignKey("dbo.Universities", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UniversityId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.DomainUsers", "ProjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "CreatorId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Projects", "CreatorId");
            AddForeignKey("dbo.Projects", "CreatorId", "dbo.DomainUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UniversityStudent", "UserId", "dbo.Universities");
            DropForeignKey("dbo.UniversityStudent", "UniversityId", "dbo.DomainUsers");
            DropForeignKey("dbo.Projects", "CreatorId", "dbo.DomainUsers");
            DropIndex("dbo.UniversityStudent", new[] { "UserId" });
            DropIndex("dbo.UniversityStudent", new[] { "UniversityId" });
            DropIndex("dbo.Projects", new[] { "CreatorId" });
            DropColumn("dbo.Projects", "CreatorId");
            DropColumn("dbo.DomainUsers", "ProjectId");
            DropTable("dbo.UniversityStudent");
        }
    }
}
