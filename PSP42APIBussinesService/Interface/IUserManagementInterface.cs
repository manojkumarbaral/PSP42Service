using BusinessEntities;
using BusinessEntities.MasterModel;
using BusinessEntities.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService.Interface
{
    public interface IUserManagementInterface
    {
        Task<IEnumerable<SuccesModel>> SubmitUserManagementCreation(UserMasterModel submitUsermaster);
        Task<IEnumerable<UserMasterModel>> getUserManagementDetailsById(int userManagement_ID, int TPACustomerID);

        Task<IEnumerable<SuccesModel>> SubmitUpdateAgentDetails(MS_Agent MS_Agent);
        Task<IEnumerable<MS_Agent>> getAgentDetailsById(int AgentID);
        Task<IEnumerable<MS_Agent>> getAllAgentDetails();

        Task<IEnumerable<SuccesModel>> SubmitUpdateBrokerMasterDetails(MS_Broker mS_Broker);
        Task<IEnumerable<MS_Broker>> getAllBrokerMasterDetails();
        Task<IEnumerable<MS_Broker>> getBrokerMasterDetailsById(int broker_ID);


        Task<IEnumerable<MS_Branch>> getAgentBranchDetailsById(int AgentID);
        Task<IEnumerable<MS_Branch>> getAllAgentBranchDetails();    
        Task<IEnumerable<MS_Branch>> getBrokerBranchDetailsById(int Branch_ID);
        Task<IEnumerable<MS_Branch>> getAllBrokerBranchDetails();
        Task<IEnumerable<SuccesModel>> SubmitUpdateBrokerBranchDetails(MS_Branch MS_Branch);
    }
}
