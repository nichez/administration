namespace Itc.Am.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserModels", "RoleName", c => c.String());
            DropColumn("dbo.UserModels", "Roles");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserModels", "Roles", c => c.String());
            DropColumn("dbo.UserModels", "RoleName");
        }
    }
}
