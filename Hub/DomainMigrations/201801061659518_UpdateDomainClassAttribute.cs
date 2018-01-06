namespace Hub.DomainMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDomainClassAttribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Universities", "UniName", c => c.String());
            AddColumn("dbo.Universities", "State", c => c.String());
            DropColumn("dbo.Universities", "Name");
            DropColumn("dbo.Universities", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Universities", "Location", c => c.String());
            AddColumn("dbo.Universities", "Name", c => c.String());
            DropColumn("dbo.Universities", "State");
            DropColumn("dbo.Universities", "UniName");
        }
    }
}
