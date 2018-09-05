using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask_TENDER.Models
{
    public class TenderViewModel
    { 
        public int Id { get; set; }
        public string TenderSubject { get; set; }   
        public string TenderDescription { get; set; }
        public decimal initialRate { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime TenderStartData { get; set; }
        public DateTime TenderEndData { get; set; }
        public string TenderType { get; set; }
        public string TenderClassification { get; set; }
        public string TenderOrganized { get; set; }
        public string TenderCurrency { get; set; }
        public List<string> TypesDictionary { get; set; }
        public List<string > OrganizedDictionary { get; set; }
        public List<string> CurrencyDictionary { get; set; }
        public List<string> ClassificationDictionary { get; set; }
    }
}