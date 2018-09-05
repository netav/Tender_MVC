using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask_TENDER.Domain;

namespace TestTask_TENDER.Repository
{
    interface ITenderRepository
    {
        List<Tender> GetAll();
        Tender GetById(int id);
        void AddTender(Tender tender);
    }
}
