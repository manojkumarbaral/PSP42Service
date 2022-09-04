using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.MasterModel
{
    public class MS_Agent
    {
        public int AgentID { get; set; }
        public string? AgentName { get; set; }
        public int AgentCODE { get; set; }
        public string? LocationType { get; set; }
        public string? Center { get; set; }
        public string? Location { get; set; }
        public int CreatedBy { get; set; }
        public string? action { get; set; }
        public bool IsActive { get; set; }
        public int tpaCustomerID { get; set; }
    }
}
