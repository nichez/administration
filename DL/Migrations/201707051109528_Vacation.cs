namespace Itc.Am.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vacation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vacations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Status = c.Boolean(),
                        Wait = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserModels", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacations", "UserId", "dbo.UserModels");
            DropIndex("dbo.Vacations", new[] { "UserId" });
            DropTable("dbo.Vacations");
        }
    }
}
