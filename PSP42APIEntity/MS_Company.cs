using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class MS_Company
    {
        [Key]
        public int Company_ID { get; set; }
        public int CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyRegdNo { get; set; }
        public string CompanyAddres { get; set; }
        public int Country_ID { get; set; }
        public int State_ID { get; set; }
    }
}
