using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessEntities.Member
{
    public class MemberDetailsModel
    {
        public DateTime Policy_StartDate { get; set; }
        public int MemberType { get; set; }
        public string MemberFName { get; set; }
        public string MemberMName { get; set; }
        public string MemberLName { get; set; }
        public int Gender { get; set; }
        public DateTime DOB { get; set; }
        public int VisaEmirateID { get; set; }
        public int Nationality { get; set; }
        public bool IsMarried { get; set; }
        public string PassportNo { get; set; }
        public string UIDNumber { get; set; }
        public string EmiratesID { get; set; }
        public int ResidentialLocation { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Occupation { get; set; }
        public int SalaryRange { get; set; }
        public int RelationID { get; set; }
        public string ApplicationNumber { get; set; }
        public int Visatype { get; set; }
    }
}
