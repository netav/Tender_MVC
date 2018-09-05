using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask_TENDER.Domain;
using TestTask_TENDER.Models;
using TestTask_TENDER.Repository;

namespace TestTask_TENDER.Service
{
    public class TenderService : ITenderService
    {
        private ITenderRepository _tenderRepository;

        public TenderService()
        {
            _tenderRepository = new TenderRepository();
        }

        public void AddTender(TenderViewModel model)
        {
            
            Tender tender = new Tender
            {
                InitialRate = model.initialRate,
                TenderSubject = model.TenderSubject,
                TenderType = { Type = model.TenderType },
                TenderDescription = model.TenderDescription,
                PublicationDate = DateTime.Now,
                TenderClassification = { ClassificationType = model.TenderClassification },
                TenderCurrency = { CurrencyType = model.TenderCurrency },
                TenderOrganizer = { Organizer = model.TenderOrganized },
                TenderEndData = model.TenderEndData,
                TenderStartData = model.TenderStartData
            };
            _tenderRepository.AddTender(tender);
        }

        public List<TenderViewModel> GetAll()
        {
            var tenders = _tenderRepository.GetAll();
            

            return tenders.Select(_ => new TenderViewModel
            {
                Id = _.Id,
                initialRate = _.InitialRate,
                TenderSubject = _.TenderSubject,
                TenderType = _.TenderType.Type,
                TenderDescription = _.TenderDescription,
                PublicationDate = _.PublicationDate,
                TenderClassification = _.TenderClassification.ClassificationType,
                TenderCurrency = _.TenderCurrency.CurrencyType,
                TenderOrganized = _.TenderOrganizer.Organizer,
                TenderEndData = _.TenderEndData,
                TenderStartData = _.TenderStartData,
                TypesDictionary = _GetUiqueTypes(tenders),
                OrganizedDictionary =_GetUiqueOrganizer(tenders),
                ClassificationDictionary = _GetUiqueClassification(tenders),
                CurrencyDictionary = _GetUiqueCurrency(tenders)
            }).ToList();
        }       

        public TenderViewModel GetById(int id)
        {
             Tender tender = _tenderRepository.GetById(id);

            return new TenderViewModel
            {
                Id = tender.Id,
                initialRate = tender.InitialRate,
                PublicationDate = tender.PublicationDate,
                TenderClassification = tender.TenderClassification.ClassificationType,
                TenderCurrency = tender.TenderCurrency.CurrencyType,
                TenderDescription = tender.TenderDescription,
                TenderEndData = tender.TenderEndData,
                TenderOrganized = tender.TenderOrganizer.Organizer,
                TenderStartData = tender.TenderStartData,
                TenderSubject = tender.TenderSubject,
                TenderType = tender.TenderType.Type
            };
        }


        private List<string> _GetUiqueTypes(List<Tender> tenders)
        {
            return tenders.Select(x => x.TenderType.Type).Distinct().ToList();
        }
        private List<string> _GetUiqueOrganizer(List<Tender> tenders)
        {
            return tenders.Select(x => x.TenderOrganizer.Organizer).Distinct().ToList();
        }
        private List<string> _GetUiqueCurrency(List<Tender> tenders)
        {
            return tenders.Select(x => x.TenderCurrency.CurrencyType).Distinct().ToList();
        }
        private List<string> _GetUiqueClassification(List<Tender> tenders)
        {
            return tenders.Select(x => x.TenderClassification.ClassificationType).Distinct().ToList();
        }
    }
}