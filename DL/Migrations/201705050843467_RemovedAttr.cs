namespace Itc.Am.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAttr : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserModels", "Department");
            DropColumn("dbo.UserModels", "Position");
            DropColumn("dbo.UserModels", "Company");
            DropColumn("dbo.UserModels", "RememberMe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserModels", "RememberMe", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserModels", "Company", c => c.String());
            AddColumn("dbo.UserModels", "Position", c => c.String());
            AddColumn("dbo.UserModels", "Department", c => c.String());
        }
    }
}
