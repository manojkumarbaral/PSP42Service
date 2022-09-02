using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.MasterModel
{
    public class UserMasterModel
    {
        public long UserID { get; set; }
        public string? UserType { get; set; }
        public int UserTypeID { get; set; }
        public int TPACustomerID { get; set; }

        public int AgentID { get; set; }
        public int BranchID { get; set; }
        public int BrokerID { get; set; }
        public string? TempPassword { get; set; }
        public string? LogInUserID { get; set; }
        public string? LoginPassword { get; set; }
        public string? LoginName { get; set; }
        public string? SponsorEmail { get; set; }
        public string? SponsorName { get; set; }
        public string? SponsorMobileNo { get; set; }
        public bool CashAllow { get; set; }
        public bool ChequeAllow { get; set; }
        public bool CardAllow { get; set; }
        public bool SwipeMechineAllow { get; set; }
        public string? Cashlimit { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public string? action { get; set; }
    }
}
