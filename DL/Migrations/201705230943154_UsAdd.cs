namespace Itc.Am.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsAdd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAddresses", "Id", c => c.Int(identity: true, nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}
