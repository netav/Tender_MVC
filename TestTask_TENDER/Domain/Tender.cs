using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask_TENDER.Domain
{
    public class Tender
    {
        public int Id { get; set; }
        public string TenderSubject { get; set; }
        public string TenderDescription { get; set; }
        public decimal InitialRate { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime TenderStartData { get; set; }
        public DateTime TenderEndData { get; set; }

        public TenderType TenderType { get; set; }
        public int TenderTypeId { get; set; }

        public TenderClassification TenderClassification { get; set; }
        public int TenderClassificationID { get; set; }

        public TenderOrganizer TenderOrganizer { get; set; }
        public int TenderOrganizerId { get; set; }

        public TenderCurrency TenderCurrency { get; set; }
        public int TenderCurrencyId { get; set; }
    }
}