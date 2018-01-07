namespace Hub.DomainMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddM2MRelationshipToUsersAndProjects : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "CreatorId", "dbo.DomainUsers");
            DropIndex("dbo.Projects", new[] { "CreatorId" });
            CreateTable(
                "dbo.UserProjects",
                c => new
                    {
                        ProjectId = c.String(nullable: false, maxLength: 128),
                        DomainUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.DomainUserId })
                .ForeignKey("dbo.DomainUsers", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.DomainUserId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.DomainUserId);
            
            DropColumn("dbo.DomainUsers", "ProjectId");
            DropColumn("dbo.Projects", "CreatorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "CreatorId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.DomainUsers", "ProjectId", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserProjects", "DomainUserId", "dbo.Projects");
            DropForeignKey("dbo.UserProjects", "ProjectId", "dbo.DomainUsers");
            DropIndex("dbo.UserProjects", new[] { "DomainUserId" });
            DropIndex("dbo.UserProjects", new[] { "ProjectId" });
            DropTable("dbo.UserProjects");
            CreateIndex("dbo.Projects", "CreatorId");
            AddForeignKey("dbo.Projects", "CreatorId", "dbo.DomainUsers", "Id", cascadeDelete: true);
        }
    }
}
