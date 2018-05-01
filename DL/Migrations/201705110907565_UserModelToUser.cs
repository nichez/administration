namespace Itc.Am.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserModelToUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAddresses", "Id", "dbo.UserModels");
            DropForeignKey("dbo.UserModelAddresses", "UserModel_Id", "dbo.UserModels");
            DropIndex("dbo.UserAddresses", new[] { "Id" });
            RenameColumn(table: "dbo.UserModelAddresses", name: "UserModel_Id", newName: "UserModel_UserId");
            RenameIndex(table: "dbo.UserModelAddresses", name: "IX_UserModel_Id", newName: "IX_UserModel_UserId");
            DropPrimaryKey("dbo.UserModels");
            DropPrimaryKey("dbo.UserAddresses");
            DropColumn("dbo.UserModels", "Id");
            DropColumn("dbo.UserAddresses", "UserAddressId");
            AddColumn("dbo.UserModels", "UserId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UserAddresses", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserAddresses", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserModels", "UserId");
            AddPrimaryKey("dbo.UserAddresses", "Id");
            CreateIndex("dbo.UserAddresses", "UserId");
            AddForeignKey("dbo.UserAddresses", "UserId", "dbo.UserModels", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.UserModelAddresses", "UserModel_UserId", "dbo.UserModels", "UserId", cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAddresses", "UserAddressId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UserModels", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.UserModelAddresses", "UserModel_UserId", "dbo.UserModels");
            DropForeignKey("dbo.UserAddresses", "UserId", "dbo.UserModels");
            DropIndex("dbo.UserAddresses", new[] { "UserId" });
            DropPrimaryKey("dbo.UserAddresses");
            DropPrimaryKey("dbo.UserModels");
            AlterColumn("dbo.UserAddresses", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.UserAddresses", "UserId");
            DropColumn("dbo.UserModels", "UserId");
            AddPrimaryKey("dbo.UserAddresses", "UserAddressId");
            AddPrimaryKey("dbo.UserModels", "Id");
            RenameIndex(table: "dbo.UserModelAddresses", name: "IX_UserModel_UserId", newName: "IX_UserModel_Id");
            RenameColumn(table: "dbo.UserModelAddresses", name: "UserModel_UserId", newName: "UserModel_Id");
            CreateIndex("dbo.UserAddresses", "Id");
            AddForeignKey("dbo.UserModelAddresses", "UserModel_Id", "dbo.UserModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserAddresses", "Id", "dbo.UserModels", "Id", cascadeDelete: true);
        }
    }
}
