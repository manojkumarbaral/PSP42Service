using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessEntities.Member
{
    public class MemberSuccess
    {
        public bool isSuccess { get; set; }
        public int SponsorTID { get; set; }
        public string Member_ID { get; set; }
        public string UIDNumber { get; set; }
        public string customerCode { get; set; }
        public string TypeNotFound { get; set; }
    }
}
