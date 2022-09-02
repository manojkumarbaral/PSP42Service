using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class MemberListModel
    {
        public int slno { get; set; }
        public string MemberName { get; set; }
        public DateTime? InceptionDate { get; set; }
        public double PremiumAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string PolicyStatus { get; set; }

        public bool IsValueExit { get; set; }
        public int SponsorTID { get; set; }
        public int Member_ID { get; set; }
    }
}
