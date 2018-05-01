namespace Itc.Am.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorktimeChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorktimeRecords", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.WorktimeRecords", "Time", c => c.DateTime(nullable: false));
            DropColumn("dbo.WorktimeRecords", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorktimeRecords", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.WorktimeRecords", "Time");
            DropColumn("dbo.WorktimeRecords", "Date");
        }
    }
}
