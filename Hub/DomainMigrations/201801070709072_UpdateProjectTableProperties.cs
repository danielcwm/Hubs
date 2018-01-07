namespace Hub.DomainMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProjectTableProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "VisitedCount", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "Liked", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Liked");
            DropColumn("dbo.Projects", "VisitedCount");
        }
    }
}
