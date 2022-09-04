using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace BusinessEntities.MasterModel
{
    public class MS_Broker
    {
        public int Broker_ID { get; set; }
        public string? BrokerName { get; set; }
        public string? BrokerCode { get; set; }
        public string? Broker_Trade_Lic_No { get; set; }
        public string? Broker_Tel { get; set; }
        public string? Broker_Email { get; set; }
        public string? CallCenter_GenEnquiryPhNo { get; set; }
        public int Broker_Address_Country_ID { get; set; }
        public int Broker_Address_State_ID { get; set; }
        public int Broker_Address_City_ID { get; set; }
        public string? Broker_Address_Street1 { get; set; }
        public string? Broker_Address_Street2 { get; set; }
        public string? action { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public string? CountryName { get; set; }
        public string? StateName { get; set; }
    }
}
