using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessEntities.LoginModel
{
    public class UserDetailsData
    {
        public long UserID { get; set; }
        public int UserType { get; set; }
        public int TPACustomerID { get; set; }
        public string LogInUserID { get; set; }
        public string LoginName { get; set; }
        public string SponsorEmail { get; set; }
        public string SponsorName { get; set; }
        public string SponsorMobileNo { get; set; }
        public bool IsActive { get; set; }
        public string LogoPath { get; set; }
        public string CustomerCode { get; set; }
    }
}
