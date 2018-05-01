namespace Itc.Am.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "UserModel_UserId", "dbo.UserModels");
            DropForeignKey("dbo.Addresses", "UserId_UserId", "dbo.UserModels");
            DropForeignKey("dbo.UserModels", "Address_AddressId", "dbo.Addresses");
            DropIndex("dbo.Addresses", new[] { "UserModel_UserId" });
            DropIndex("dbo.Addresses", new[] { "UserId_UserId" });
            DropIndex("dbo.UserModels", new[] { "Address_AddressId" });
            CreateTable(
                "dbo.UserModelAddresses",
                c => new
                    {
                        UserModel_UserId = c.Int(nullable: false),
                        Address_AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserModel_UserId, t.Address_AddressId })
                .ForeignKey("dbo.UserModels", t => t.UserModel_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressId, cascadeDelete: true)
                .Index(t => t.UserModel_UserId)
                .Index(t => t.Address_AddressId);
            
            DropColumn("dbo.Addresses", "UserModel_UserId");
            DropColumn("dbo.Addresses", "UserId_UserId");
            DropColumn("dbo.UserModels", "Address_AddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserModels", "Address_AddressId", c => c.Int());
            AddColumn("dbo.Addresses", "UserId_UserId", c => c.Int());
            AddColumn("dbo.Addresses", "UserModel_UserId", c => c.Int());
            DropForeignKey("dbo.UserModelAddresses", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.UserModelAddresses", "UserModel_UserId", "dbo.UserModels");
            DropIndex("dbo.UserModelAddresses", new[] { "Address_AddressId" });
            DropIndex("dbo.UserModelAddresses", new[] { "UserModel_UserId" });
            DropTable("dbo.UserModelAddresses");
            CreateIndex("dbo.UserModels", "Address_AddressId");
            CreateIndex("dbo.Addresses", "UserId_UserId");
            CreateIndex("dbo.Addresses", "UserModel_UserId");
            AddForeignKey("dbo.UserModels", "Address_AddressId", "dbo.Addresses", "AddressId");
            AddForeignKey("dbo.Addresses", "UserId_UserId", "dbo.UserModels", "UserId");
            AddForeignKey("dbo.Addresses", "UserModel_UserId", "dbo.UserModels", "UserId");
        }
    }
}
