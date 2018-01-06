namespace Hub.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAdminRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bb7a13b3-50d9-4261-9070-3b7e5bea7632', N'choiwaim@gmail.com', 0, N'ADQQSMNtLkA3nn4VTWqyXD2z+cnoaS1V04Myd0LAJcJsGHfjvkEi70bxCHa2veI4EQ==', N'539ffd26-2ca1-4ba3-9eb1-85c8e0e9bf2a', NULL, 0, 0, NULL, 1, 0, N'choiwaim@gmail.com')");
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0', N'admin')");
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bb7a13b3-50d9-4261-9070-3b7e5bea7632', N'0')");
        }
        
        public override void Down()
        {

        }
    }
}
