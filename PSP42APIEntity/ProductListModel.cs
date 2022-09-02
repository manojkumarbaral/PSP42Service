using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class ProductListModel
    {
        public int ProductID { get; set; }
        public int TPAPlanID { get; set; }
        public string PlanName { get; set; }
        public string TOB_DocumentPath { get; set; }
        public int PlanAmount { get; set; }
        public string CompanyName { get; set; }
        public int Company_ID { get; set; }
    }
}
