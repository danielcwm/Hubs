namespace Hub.DomainMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDomainUserIdToString : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UniversityStudent", "UniversityId", "dbo.DomainUsers");
            DropForeignKey("dbo.UniversityStudent", "UserId", "dbo.Universities");
            DropIndex("dbo.UniversityStudent", new[] { "UniversityId" });
            DropIndex("dbo.UniversityStudent", new[] { "UserId" });
            DropTable("dbo.UniversityStudent");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UniversityStudent",
                c => new
                    {
                        UniversityId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UniversityId, t.UserId });
            
            CreateIndex("dbo.UniversityStudent", "UserId");
            CreateIndex("dbo.UniversityStudent", "UniversityId");
            AddForeignKey("dbo.UniversityStudent", "UserId", "dbo.Universities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UniversityStudent", "UniversityId", "dbo.DomainUsers", "Id", cascadeDelete: true);
        }
    }
}
