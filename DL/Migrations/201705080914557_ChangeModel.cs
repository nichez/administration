namespace Itc.Am.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserModels", "Email", c => c.String());
            AlterColumn("dbo.UserModels", "FirstName", c => c.String());
            AlterColumn("dbo.UserModels", "LastName", c => c.String());
            AlterColumn("dbo.UserModels", "Username", c => c.String());
            AlterColumn("dbo.UserModels", "Password", c => c.String());
            AlterColumn("dbo.UserModels", "ConfirmPassword", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserModels", "ConfirmPassword", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.UserModels", "Password", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.UserModels", "Username", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserModels", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.UserModels", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.UserModels", "Email", c => c.String(nullable: false));
        }
    }
}
