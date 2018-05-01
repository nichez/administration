namespace Itc.Am.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAddIdentity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAddresses", "Id", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAddresses", "Id", c => c.Int(nullable: false));
        }
    }
}
