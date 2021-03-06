namespace Itc.Am.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMembership : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Memberships");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Memberships",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        ConfirmationToken = c.String(),
                        IsConfirmed = c.Boolean(nullable: false),
                        LastPasswordFailureDate = c.DateTime(nullable: false),
                        PasswordFailuresSinceLastSuccess = c.Int(nullable: false),
                        Password = c.String(),
                        PasswordChangeDate = c.DateTime(nullable: false),
                        PasswordSalt = c.String(),
                        PasswordVerificationToken = c.String(),
                        PasswordVerificationTokenExpirationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
    }
}
