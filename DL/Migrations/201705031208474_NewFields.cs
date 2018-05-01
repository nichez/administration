namespace Itc.Am.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserModels", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.UserModels", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.UserModels", "Department", c => c.String());
            AddColumn("dbo.UserModels", "Position", c => c.String());
            AddColumn("dbo.UserModels", "Company", c => c.String());
        }
        
        public override void Down()
        {
            DropTable("dbo.UserModels");
        }
    }
}
