namespace Itc.Am.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Roles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.UserModels", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roles", "UserId", "dbo.UserModels");
            DropIndex("dbo.Roles", new[] { "UserId" });
            DropTable("dbo.Roles");
        }
    }
}
