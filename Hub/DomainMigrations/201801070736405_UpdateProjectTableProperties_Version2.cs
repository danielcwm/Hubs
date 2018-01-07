namespace Hub.DomainMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProjectTableProperties_Version2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Description", c => c.String());
            AddColumn("dbo.Projects", "ContactEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "ContactEmail");
            DropColumn("dbo.Projects", "Description");
        }
    }
}
