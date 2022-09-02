using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessEntities.Sponsor
{
    public class SponsorSubmit
    {
        public string SponsorEmail { get; set; }
        public string Code { get; set; }
        public string SponsorMobile { get; set; }
        public string FullName { get; set; }
        public string EIDNumber { get; set; }
        public string UIDNumber { get; set; }
        public int? CreatedBy_UID { get; set; }
        public string customerCode { get; set; }
    }
}
