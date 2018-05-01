namespace Itc.Am.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VacUpdate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vacations", "DateUpdated", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vacations", "DateUpdated");
        }
    }
}
