namespace Hub.DomainMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDomainTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DomainUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DomainUsers");
        }
    }
}
