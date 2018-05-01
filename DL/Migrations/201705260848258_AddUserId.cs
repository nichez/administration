namespace Itc.Am.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserModelAddresses", "UserModel_UserId", "dbo.UserModels");
            DropForeignKey("dbo.UserModelAddresses", "Address_AddressId", "dbo.Addresses");
            DropIndex("dbo.UserModelAddresses", new[] { "UserModel_UserId" });
            DropIndex("dbo.UserModelAddresses", new[] { "Address_AddressId" });
            AddColumn("dbo.Addresses", "UserModel_UserId", c => c.Int());
            AddColumn("dbo.Addresses", "UserId_UserId", c => c.Int());
            AddColumn("dbo.UserModels", "Address_AddressId", c => c.Int());
            CreateIndex("dbo.Addresses", "UserModel_UserId");
            CreateIndex("dbo.Addresses", "UserId_UserId");
            CreateIndex("dbo.UserModels", "Address_AddressId");
            AddForeignKey("dbo.Addresses", "UserModel_UserId", "dbo.UserModels", "UserId");
            AddForeignKey("dbo.Addresses", "UserId_UserId", "dbo.UserModels", "UserId");
            AddForeignKey("dbo.UserModels", "Address_AddressId", "dbo.Addresses", "AddressId");
            DropColumn("dbo.Addresses", "UserId");
            DropTable("dbo.UserModelAddresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserModelAddresses",
                c => new
                    {
                        UserModel_UserId = c.Int(nullable: false),
                        Address_AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserModel_UserId, t.Address_AddressId });
            
            AddColumn("dbo.Addresses", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserModels", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "UserId_UserId", "dbo.UserModels");
            DropForeignKey("dbo.Addresses", "UserModel_UserId", "dbo.UserModels");
            DropIndex("dbo.UserModels", new[] { "Address_AddressId" });
            DropIndex("dbo.Addresses", new[] { "UserId_UserId" });
            DropIndex("dbo.Addresses", new[] { "UserModel_UserId" });
            DropColumn("dbo.UserModels", "Address_AddressId");
            DropColumn("dbo.Addresses", "UserId_UserId");
            DropColumn("dbo.Addresses", "UserModel_UserId");
            CreateIndex("dbo.UserModelAddresses", "Address_AddressId");
            CreateIndex("dbo.UserModelAddresses", "UserModel_UserId");
            AddForeignKey("dbo.UserModelAddresses", "Address_AddressId", "dbo.Addresses", "AddressId", cascadeDelete: true);
            AddForeignKey("dbo.UserModelAddresses", "UserModel_UserId", "dbo.UserModels", "UserId", cascadeDelete: true);
        }
    }
}
