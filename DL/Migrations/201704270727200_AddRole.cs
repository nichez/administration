namespace DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserModels", "Roles", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserModels", "Roles");
        }
    }
}
