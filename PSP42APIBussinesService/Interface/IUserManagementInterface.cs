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
    }
}
