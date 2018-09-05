namespace TestTask_TENDER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDstartENDtime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tenders", "TenderStartData", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tenders", "TenderEndData", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tenders", "TenderEndData");
            DropColumn("dbo.Tenders", "TenderStartData");
        }
    }
}
