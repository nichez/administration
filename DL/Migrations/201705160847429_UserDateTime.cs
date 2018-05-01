namespace Itc.Am.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserModels", "DateUpdated", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserModels", "DateUpdated");
        }
    }
}
