using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class MS_Customer
    {
        [Key]
        public int TPACustomer_ID { get; set; }
        public string CustomerCode { get; set; }
        public int CustomerType { get; set; }
        public string CustomerName { get; set; }
        
    }
}
