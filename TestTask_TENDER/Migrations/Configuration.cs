namespace TestTask_TENDER.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Domain;

    internal sealed class Configuration : DbMigrationsConfiguration<TestTask_TENDER.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestTask_TENDER.Data.AppDbContext context)
        {
            context.tenderTypes.AddOrUpdate(_ => _.Type, new TenderType { Type = "Открытые торги" });
            context.tenderTypes.AddOrUpdate(_ => _.Type, new TenderType { Type = "Закрытые торги" });
            context.tenderTypes.AddOrUpdate(_ => _.Type, new TenderType { Type = "Анализ цен" });
            context.SaveChanges();

            context.tenderClassifications.AddOrUpdate(_ => _.ClassificationType, new TenderClassification {ClassificationType = "Химическая продукция " });
            context.tenderClassifications.AddOrUpdate(_ => _.ClassificationType, new TenderClassification { ClassificationType = "Одежда , обувь , сумки , аксесуары " });
            context.tenderClassifications.AddOrUpdate(_ => _.ClassificationType, new TenderClassification { ClassificationType = "Нефтепродукты, топливо, электроэнергия " });
            context.tenderClassifications.AddOrUpdate(_ => _.ClassificationType, new TenderClassification { ClassificationType = "Печатная продукция" });
            context.SaveChanges();

            context.tenderCurrencies.AddOrUpdate(_ => _.CurrencyType, new TenderCurrency { CurrencyType = "Гривна" });
            context.tenderCurrencies.AddOrUpdate(_ => _.CurrencyType, new TenderCurrency { CurrencyType = "Евро" });
            context.tenderCurrencies.AddOrUpdate(_ => _.CurrencyType, new TenderCurrency { CurrencyType = "Доллар" });
            context.SaveChanges();

            context.tenderOrganizers.AddOrUpdate(_ => _.Organizer, new TenderOrganizer { Organizer = "Киевский метрополитен" });
            context.tenderOrganizers.AddOrUpdate(_ => _.Organizer, new TenderOrganizer { Organizer = "Энергоатом" });
            context.tenderOrganizers.AddOrUpdate(_ => _.Organizer, new TenderOrganizer { Organizer = "Укрзализныця" });
            context.tenderOrganizers.AddOrUpdate(_ => _.Organizer, new TenderOrganizer { Organizer = "Укрэнерго" });
            context.SaveChanges();

            context.tenders.AddOrUpdate(_ => _.TenderSubject, new Tender
            {
                Id = 1,
                TenderSubject = "Test tender",
                TenderDescription = "This is test tender form",
                InitialRate = 12304.42M,
                PublicationDate = new DateTime(2018, 07, 15, 9, 43, 12),
                TenderTypeId = 1,
                TenderClassificationID = 2,
                TenderCurrencyId = 1,
                TenderOrganizerId = 4,
                TenderStartData = new DateTime(2018 , 07 , 16,9, 43, 12),
                TenderEndData = new DateTime(2018 , 07 , 20, 9, 43, 12)
                
            });
            context.tenders.AddOrUpdate(_ => _.TenderSubject, new Tender
            {
                Id = 2,
                TenderSubject = "WebSite",
                TenderDescription = "Develop site for company",
                InitialRate = 10000.42M,
                PublicationDate = new DateTime(2018, 09, 05, 10, 00, 02),
                TenderTypeId = 1,
                TenderClassificationID = 4,
                TenderCurrencyId = 3,
                TenderOrganizerId = 3,
                TenderStartData = new DateTime(2018, 09, 06),
                TenderEndData = new DateTime(2018, 09, 20)

            });
            context.tenders.AddOrUpdate(_ => _.TenderSubject, new Tender
            {
                Id = 3,
                TenderSubject = "Oil",
                TenderDescription = "3 tons of oil",
                InitialRate = 50000.42M,
                PublicationDate = new DateTime(2018, 09, 06, 10, 00, 02),
                TenderTypeId = 3,
                TenderClassificationID = 3,
                TenderCurrencyId = 2,
                TenderOrganizerId = 1,
                TenderStartData = new DateTime(2018, 09, 06),
                TenderEndData = new DateTime(2018, 09, 20)

            });
            context.tenders.AddOrUpdate(_ => _.TenderSubject, new Tender
            {
                Id = 4,
                TenderSubject = "uranium",
                TenderDescription = "uranium with transport to a specified place",
                InitialRate = 1000000.42M,
                PublicationDate = new DateTime(2018, 09, 05, 10, 00, 02),
                TenderTypeId = 2,
                TenderClassificationID = 1,
                TenderCurrencyId = 2,
                TenderOrganizerId = 2,
                TenderStartData = new DateTime(2018, 10, 06),
                TenderEndData = new DateTime(2018, 11, 20)

            });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
