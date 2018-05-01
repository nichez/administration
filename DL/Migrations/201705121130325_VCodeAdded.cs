namespace Itc.Am.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VCodeAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserModels", "VCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserModels", "VCode");
        }
    }
}
