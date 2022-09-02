using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DocumentSearchModel
    {
        public string UID { get; set; }
        public string EID { get; set; }
        public int? SponsorTID { get; set; }
    }
}
