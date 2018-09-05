using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestTask_TENDER.Domain;

namespace TestTask_TENDER.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Tender> tenders { get; set; }
        public DbSet<TenderType> tenderTypes { get; set; }
        public DbSet<TenderClassification> tenderClassifications { get; set; }
        public DbSet<TenderOrganizer> tenderOrganizers { get; set; }
        public DbSet<TenderCurrency> tenderCurrencies { get; set; }
    }
}