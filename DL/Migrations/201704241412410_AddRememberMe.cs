namespace DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRememberMe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserModels", "RememberMe", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserModels", "RememberMe");
        }
    }
}
