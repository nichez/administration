namespace Itc.Am.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Addresses", "UserId");
        }
    }
}
