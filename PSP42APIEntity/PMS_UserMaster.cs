using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class PMS_UserMaster
    {
        [Key]
        public long UserID { get; set; }
        public int UserType { get; set; }
        public int TPACustomerID { get; set; }
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
        public bool IsActive { get; set; }
    }
}
