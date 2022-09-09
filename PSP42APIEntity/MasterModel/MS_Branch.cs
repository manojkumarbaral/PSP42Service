using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace BusinessEntities.MasterModel
{
    public class MS_Branch
    {
        public int Broker_ID { get; set; }
        public int AgentID { get; set; }
        public int CompanyId { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchName { get; set; }
        public string? BranchAddress { get; set; }
        public int Country_ID { get; set; }
        public string? CountryName { get; set; }
        public int State_ID { get; set; }
        public string? StateName { get; set; }
        public int City_ID { get; set; }
        public string? OfficePhone { get; set; }
        public string? CCPhone { get; set; }
        public string? OperationAdminAcc_Dep_Phone { get; set; }
        public string? Email { get; set; }


        public string? BranchOpeningTime { get; set; }

        public string? BranchClosingTime { get; set; }
        public string? action { get; set; }
        public int CreatedBy { get; set; }
        public int Branch_ID { get; set; }
        public bool IsActive { get; set; }
        public string? type { get; set; }
    }
}
