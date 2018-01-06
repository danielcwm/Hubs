namespace Hub.DomainMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDomainClassAttribute1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Universities", "UnitId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Universities", "UnitId", c => c.Int(nullable: false));
        }
    }
}
