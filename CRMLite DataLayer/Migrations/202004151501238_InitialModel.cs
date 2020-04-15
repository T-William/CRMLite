namespace CRMLite_DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountHolders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedDateTime = c.DateTime(),
                        UserId = c.String(maxLength: 10),
                        Name = c.String(maxLength: 100),
                        StatusId = c.Int(nullable: false),
                        KycLevel = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedDateTime = c.DateTime(),
                        AccountNumber = c.String(maxLength: 10),
                        AccountHolderId = c.Long(),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountHolders", t => t.AccountHolderId)
                .Index(t => t.AccountHolderId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedDateTime = c.DateTime(),
                        AccountHolderId = c.Long(nullable: false),
                        AddressTypeId = c.Int(nullable: false),
                        Description = c.String(maxLength: 100),
                        AddressLine1 = c.String(maxLength: 100),
                        AddressLine2 = c.String(maxLength: 100),
                        AddressLine3 = c.String(maxLength: 100),
                        Locality = c.String(maxLength: 50),
                        Region = c.String(maxLength: 50),
                        Country = c.String(maxLength: 50),
                        PostalCode = c.String(maxLength: 20),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountHolders", t => t.AccountHolderId, cascadeDelete: true)
                .Index(t => t.AccountHolderId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedDateTime = c.DateTime(),
                        AccountHolderId = c.Long(),
                        Value = c.String(maxLength: 50),
                        ContactTypeId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountHolders", t => t.AccountHolderId)
                .Index(t => t.AccountHolderId);
            
            CreateTable(
                "dbo.IdentityDocuments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedDateTime = c.DateTime(),
                        Number = c.String(maxLength: 20),
                        IdentityDocumentTypeId = c.Int(nullable: false),
                        ExpiryDate = c.DateTime(),
                        IndividualAccountHolderId = c.Long(),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IndividualAccountHolders", t => t.IndividualAccountHolderId)
                .Index(t => t.IndividualAccountHolderId);
            
            CreateTable(
                "dbo.IndividualAccountHolders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedDateTime = c.DateTime(),
                        Title = c.String(maxLength: 50),
                        Gender = c.Int(nullable: false),
                        AccountHolderId = c.Long(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Surname = c.String(maxLength: 100),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountHolders", t => t.AccountHolderId)
                .Index(t => t.AccountHolderId);
            
            CreateTable(
                "dbo.InstitutionAccountHolders",
                c => new
                    {
                        Id = c.Single(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        DeletedDateTime = c.DateTime(),
                        AccountHolderId = c.Long(nullable: false),
                        ClientAccountAccountNo = c.Long(nullable: false),
                        ClientAccountBranchCode = c.Int(nullable: false),
                        ClientAccountType = c.String(maxLength: 20),
                        RegistrationNumber = c.String(maxLength: 50),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountHolders", t => t.AccountHolderId, cascadeDelete: true)
                .Index(t => t.AccountHolderId);
            
            CreateTable(
                "dbo.LinkedUsers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RecipientId = c.Long(nullable: false),
                        UserId = c.String(maxLength: 10),
                        AccountIdWithRecipient = c.String(maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedDateTime = c.DateTime(),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountHolders", t => t.RecipientId, cascadeDelete: true)
                .Index(t => t.RecipientId);
            
            CreateTable(
                "dbo.Metas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedDateTime = c.DateTime(),
                        Key = c.String(maxLength: 50),
                        Value = c.String(maxLength: 1000),
                        AccountHolderId = c.Long(),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountHolders", t => t.AccountHolderId)
                .Index(t => t.AccountHolderId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        TransactionId = c.Guid(nullable: false),
                        CompletedDateTime = c.DateTime(nullable: false),
                        Reference = c.String(maxLength: 100),
                        AmountValue = c.Long(nullable: false),
                        AmountCurrency = c.String(maxLength: 3),
                        CurrentBalance = c.Long(nullable: false),
                        AccountId = c.Long(nullable: false),
                        OtherAccountReference = c.String(maxLength: 100),
                        SenderOrReceiver = c.Int(nullable: false),
                        TransactionType = c.Int(nullable: false),
                        DebitOrCredit = c.Int(nullable: false),
                        ClearedDateTime = c.Int(nullable: false),
                        OtherAccountId = c.Long(),
                        BatchNo = c.Long(),
                        LinkedTransactionId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedDateTime = c.DateTime(),
                        Role = c.Int(nullable: false),
                        AccountHolderId = c.Long(),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountHolders", t => t.AccountHolderId)
                .Index(t => t.AccountHolderId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserRoles", "AccountHolderId", "dbo.AccountHolders");
            DropForeignKey("dbo.Transactions", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Metas", "AccountHolderId", "dbo.AccountHolders");
            DropForeignKey("dbo.LinkedUsers", "RecipientId", "dbo.AccountHolders");
            DropForeignKey("dbo.InstitutionAccountHolders", "AccountHolderId", "dbo.AccountHolders");
            DropForeignKey("dbo.IdentityDocuments", "IndividualAccountHolderId", "dbo.IndividualAccountHolders");
            DropForeignKey("dbo.IndividualAccountHolders", "AccountHolderId", "dbo.AccountHolders");
            DropForeignKey("dbo.Contacts", "AccountHolderId", "dbo.AccountHolders");
            DropForeignKey("dbo.Addresses", "AccountHolderId", "dbo.AccountHolders");
            DropForeignKey("dbo.Accounts", "AccountHolderId", "dbo.AccountHolders");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserRoles", new[] { "AccountHolderId" });
            DropIndex("dbo.Transactions", new[] { "AccountId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Metas", new[] { "AccountHolderId" });
            DropIndex("dbo.LinkedUsers", new[] { "RecipientId" });
            DropIndex("dbo.InstitutionAccountHolders", new[] { "AccountHolderId" });
            DropIndex("dbo.IndividualAccountHolders", new[] { "AccountHolderId" });
            DropIndex("dbo.IdentityDocuments", new[] { "IndividualAccountHolderId" });
            DropIndex("dbo.Contacts", new[] { "AccountHolderId" });
            DropIndex("dbo.Addresses", new[] { "AccountHolderId" });
            DropIndex("dbo.Accounts", new[] { "AccountHolderId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Transactions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Metas");
            DropTable("dbo.LinkedUsers");
            DropTable("dbo.InstitutionAccountHolders");
            DropTable("dbo.IndividualAccountHolders");
            DropTable("dbo.IdentityDocuments");
            DropTable("dbo.Contacts");
            DropTable("dbo.Addresses");
            DropTable("dbo.Accounts");
            DropTable("dbo.AccountHolders");
        }
    }
}
