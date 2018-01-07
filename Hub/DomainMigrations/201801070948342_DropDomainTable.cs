namespace Hub.DomainMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropDomainTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.DomainUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DomainUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
