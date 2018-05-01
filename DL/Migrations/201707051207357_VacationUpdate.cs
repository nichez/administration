namespace Itc.Am.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VacationUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vacations", "Username", c => c.String());
            AddColumn("dbo.Vacations", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vacations", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vacations", "EndDate");
            DropColumn("dbo.Vacations", "StartDate");
            DropColumn("dbo.Vacations", "Username");
        }
    }
}
