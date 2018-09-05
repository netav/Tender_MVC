namespace TestTask_TENDER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TenderClassifications",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ClassificationType = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TenderCurrencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrencyType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TenderOrganizers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Organizer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tenders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenderSubject = c.String(),
                        TenderDescription = c.String(),
                        InitialRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PublicationDate = c.DateTime(nullable: false),
                        TenderTypeId = c.Int(nullable: false),
                        TenderClassificationID = c.Int(nullable: false),
                        TenderOrganizerId = c.Int(nullable: false),
                        TenderCurrencyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TenderClassifications", t => t.TenderClassificationID, cascadeDelete: true)
                .ForeignKey("dbo.TenderCurrencies", t => t.TenderCurrencyId, cascadeDelete: true)
                .ForeignKey("dbo.TenderOrganizers", t => t.TenderOrganizerId, cascadeDelete: true)
                .ForeignKey("dbo.TenderTypes", t => t.TenderTypeId, cascadeDelete: true)
                .Index(t => t.TenderTypeId)
                .Index(t => t.TenderClassificationID)
                .Index(t => t.TenderOrganizerId)
                .Index(t => t.TenderCurrencyId);
            
            CreateTable(
                "dbo.TenderTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tenders", "TenderTypeId", "dbo.TenderTypes");
            DropForeignKey("dbo.Tenders", "TenderOrganizerId", "dbo.TenderOrganizers");
            DropForeignKey("dbo.Tenders", "TenderCurrencyId", "dbo.TenderCurrencies");
            DropForeignKey("dbo.Tenders", "TenderClassificationID", "dbo.TenderClassifications");
            DropIndex("dbo.Tenders", new[] { "TenderCurrencyId" });
            DropIndex("dbo.Tenders", new[] { "TenderOrganizerId" });
            DropIndex("dbo.Tenders", new[] { "TenderClassificationID" });
            DropIndex("dbo.Tenders", new[] { "TenderTypeId" });
            DropTable("dbo.TenderTypes");
            DropTable("dbo.Tenders");
            DropTable("dbo.TenderOrganizers");
            DropTable("dbo.TenderCurrencies");
            DropTable("dbo.TenderClassifications");
        }
    }
}
