namespace Itc.Am.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAddress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        UserAddressId = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserAddressId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.UserModels", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.UserModelAddresses",
                c => new
                    {
                        UserModel_Id = c.Int(nullable: false),
                        Address_AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserModel_Id, t.Address_AddressId })
                .ForeignKey("dbo.UserModels", t => t.UserModel_Id, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressId, cascadeDelete: true)
                .Index(t => t.UserModel_Id)
                .Index(t => t.Address_AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAddresses", "Id", "dbo.UserModels");
            DropForeignKey("dbo.UserAddresses", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.UserModelAddresses", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.UserModelAddresses", "UserModel_Id", "dbo.UserModels");
            DropIndex("dbo.UserModelAddresses", new[] { "Address_AddressId" });
            DropIndex("dbo.UserModelAddresses", new[] { "UserModel_Id" });
            DropIndex("dbo.UserAddresses", new[] { "AddressId" });
            DropIndex("dbo.UserAddresses", new[] { "Id" });
            DropTable("dbo.UserModelAddresses");
            DropTable("dbo.UserAddresses");
        }
    }
}
