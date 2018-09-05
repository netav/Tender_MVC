using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask_TENDER.Data;
using TestTask_TENDER.Domain;

namespace TestTask_TENDER.Repository
{
    public class TenderRepository : ITenderRepository
    {
        private AppDbContext _context;

        public TenderRepository()
        {
            _context = new AppDbContext();
        }

        public void AddTender(Tender tender)
        {
            _context.tenders.Add(tender);
            _context.SaveChanges();
        }

        public List<Tender> GetAll()
        {
            return _context.tenders.
                Include("TenderType").
                Include("TenderClassification").
                Include("TenderOrganizer").
                Include("TenderCurrency").ToList();
        }

        public Tender GetById(int id)
        {
            return _context.tenders.
                Include("TenderType").
                Include("TenderClassification").
                Include("TenderOrganizer").
                Include("TenderCurrency").FirstOrDefault(_ => _.Id == id);
        }
    }
}