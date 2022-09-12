using BusinessEntities;
using BusinessEntities.MasterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessService.Interface
{
    public interface IMasterInterface
    {
        Task<IEnumerable<tbl_MST_CountryMaster>> getCountryCode();
        Task<IEnumerable<MS_MemberType>> getMemberType();
        Task<IEnumerable<MS_GenderMaster>> getGenderMaster();
        Task<IEnumerable<MS_VisaEmirate>> getVisaEmirateMaster(int iCountryID);
        Task<IEnumerable<MS_Country>> getCountryMaster();
        Task<IEnumerable<MS_ResidentialEmirate>> getResidentialEmirateMaster();
        Task<IEnumerable<MS_Salary>> getSalaryRange();
        Task<IEnumerable<MS_RelationshiptotheSponsor>> getRelationshiptotheSponsor();
        Task<IEnumerable<MS_UserTypes>> getUsertype(int userTypeID);
        Task<IEnumerable<MS_Agent>> getAgent();
        Task<IEnumerable<MS_Broker>> getBroker();
        Task<IEnumerable<MS_Branch>> getBranch();
        Task<IEnumerable<MS_Customer>> getTPACustomer(int userTypeID);
        Task<IEnumerable<UserMasterModel>> getUsermaster();
        Task<IEnumerable<MS_Branch>> getBrokerBranch();
        Task<IEnumerable<MS_Branch>> getAgentBranch();
    }
}
