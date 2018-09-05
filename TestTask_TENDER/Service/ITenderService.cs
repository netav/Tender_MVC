using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask_TENDER.Models;

namespace TestTask_TENDER.Service
{
    interface ITenderService
    {
        List<TenderViewModel> GetAll();
        TenderViewModel GetById(int id);
        void AddTender(TenderViewModel model);
    }
}
