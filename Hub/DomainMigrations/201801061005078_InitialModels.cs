namespace Hub.DomainMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DomainUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        CreatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DomainUsers", t => t.CreatorId, cascadeDelete: true)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        CreateBy = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Campus = c.String(),
                        UnitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedBy = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        UniversityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectTags",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.TagId })
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.UniversityUnits",
                c => new
                    {
                        UniversityId = c.Int(nullable: false),
                        UnitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UniversityId, t.UnitId })
                .ForeignKey("dbo.Universities", t => t.UniversityId, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.UniversityId)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.UniversityStudent",
                c => new
                    {
                        UniversityId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UniversityId, t.UserId })
                .ForeignKey("dbo.DomainUsers", t => t.UniversityId, cascadeDelete: true)
                .ForeignKey("dbo.Universities", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UniversityId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UniversityStudent", "UserId", "dbo.Universities");
            DropForeignKey("dbo.UniversityStudent", "UniversityId", "dbo.DomainUsers");
            DropForeignKey("dbo.UniversityUnits", "UnitId", "dbo.Units");
            DropForeignKey("dbo.UniversityUnits", "UniversityId", "dbo.Universities");
            DropForeignKey("dbo.Projects", "CreatorId", "dbo.DomainUsers");
            DropForeignKey("dbo.ProjectTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.ProjectTags", "ProjectId", "dbo.Projects");
            DropIndex("dbo.UniversityStudent", new[] { "UserId" });
            DropIndex("dbo.UniversityStudent", new[] { "UniversityId" });
            DropIndex("dbo.UniversityUnits", new[] { "UnitId" });
            DropIndex("dbo.UniversityUnits", new[] { "UniversityId" });
            DropIndex("dbo.ProjectTags", new[] { "TagId" });
            DropIndex("dbo.ProjectTags", new[] { "ProjectId" });
            DropIndex("dbo.Projects", new[] { "CreatorId" });
            DropTable("dbo.UniversityStudent");
            DropTable("dbo.UniversityUnits");
            DropTable("dbo.ProjectTags");
            DropTable("dbo.Units");
            DropTable("dbo.Universities");
            DropTable("dbo.Tags");
            DropTable("dbo.Projects");
            DropTable("dbo.DomainUsers");
        }
    }
}
