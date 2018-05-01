namespace Itc.Am.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VacUpdate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vacations", "Status", c => c.Int());
            DropColumn("dbo.Vacations", "Wait");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vacations", "Wait", c => c.String());
            AlterColumn("dbo.Vacations", "Status", c => c.Boolean());
        }
    }
}
