namespace Hub.DomainMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProjectTableProperties_Version5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "ContactEmail", c => c.String(nullable: false));
            AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Universities", "UniName", c => c.String(nullable: false));
            AlterColumn("dbo.Universities", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Units", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Units", "Name", c => c.String());
            AlterColumn("dbo.Universities", "State", c => c.String());
            AlterColumn("dbo.Universities", "UniName", c => c.String());
            AlterColumn("dbo.Tags", "Name", c => c.String());
            AlterColumn("dbo.Projects", "ContactEmail", c => c.String());
            AlterColumn("dbo.Projects", "Description", c => c.String());
            AlterColumn("dbo.Projects", "Title", c => c.String());
        }
    }
}
