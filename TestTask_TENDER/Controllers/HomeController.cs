using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask_TENDER.Models;
using TestTask_TENDER.Service;

namespace TestTask_TENDER.Controllers
{
    public class HomeController : Controller
    {

        private ITenderService _tenService;

        public HomeController()
        {
            _tenService = new TenderService();
        }
        [HttpGet]
        public ActionResult Index(string text)
        {
            List<TenderViewModel> tenderViewModel = _tenService.GetAll();

            return View(tenderViewModel);
        }

        [HttpPost]
        public ActionResult Index(SearchViewModel viewModel , SortViewModel viewModels)
        {

            List<TenderViewModel> tenderViewModel = _tenService.GetAll();

            if (!String.IsNullOrEmpty(viewModel.SearchText))
            {
                tenderViewModel = tenderViewModel.Where(_ => _.TenderSubject.Contains(viewModel.SearchText) ||
                _.TenderDescription.Contains(viewModel.SearchText)).ToList();
            }
            if (!String.IsNullOrEmpty(viewModels.TypeText))
            {
                tenderViewModel = tenderViewModel.Where(_ => _.TenderType.Contains(viewModels.TypeText)).ToList();
            }
            if (!String.IsNullOrEmpty(viewModels.OrganizerText))
            {
                tenderViewModel = tenderViewModel.Where(_ => _.TenderOrganized.Contains(viewModels.OrganizerText)).ToList();
            }

            return View(tenderViewModel);
        }

        [HttpGet]
        public ActionResult TenderAdd()
        {
            List<TenderViewModel> tenderViewModel = _tenService.GetAll();

            return View(tenderViewModel);
        }

        [HttpPost]
        public ActionResult TenderAdd(TenderViewModel model)
        {
            _tenService.AddTender(model);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult AllInfoTender(int id)
        {
            TenderViewModel tenderViewModel = _tenService.GetById(id);
            return View(tenderViewModel);
        }    

       
    }
}