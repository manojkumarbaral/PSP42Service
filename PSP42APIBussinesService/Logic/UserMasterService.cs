using BusinessEntities.Member;
using BusinessService.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.MasterModel;
using BusinessEntities;
using DAL;

namespace BusinessService.Logic
{
    public class UserMasterService : IUserManagementInterface
    {
        public DataLayer dl;
        public UserMasterService()
        {
            dl = new DataLayer();
        }
        public async Task<IEnumerable<SuccesModel>> SubmitUserManagementCreation(UserMasterModel Usermaster)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@UserType", Usermaster.UserTypeID);
                    param.Add("@TPACustomer", Usermaster.TPACustomerID);
                    param.Add("@Agent", Usermaster.AgentID);
                    param.Add("@Broker", Usermaster.BrokerID);
                    param.Add("@Branch", Usermaster.BranchID);
                    param.Add("@LoginName", Usermaster.LoginName);
                    param.Add("@LogInUserID", Usermaster.LogInUserID);

                    param.Add("@LoginPassword", Usermaster.LoginPassword);
                    param.Add("@TempPassword", Usermaster.TempPassword);

                    param.Add("@Email", Usermaster.SponsorEmail);
                    param.Add("@CashAllow", Usermaster.CashAllow);
                    param.Add("@ChequeAllow", Usermaster.ChequeAllow);
                    param.Add("@CardAllow", Usermaster.CardAllow);
                    param.Add("@SwipeMechineAllow", Usermaster.SwipeMechineAllow);
                    param.Add("@Cashlimit", Usermaster.Cashlimit);
                    param.Add("@Active", Usermaster.IsActive);

                    param.Add("@CreatedBy", Usermaster.CreatedBy);
                    param.Add("@action", Usermaster.action);
                    param.Add("@UserID", Usermaster.UserID);
                   
                    string sp = "USP_SubmitUpdateUserManagementCreation";
                    var result = await db.QueryAsync<SuccesModel>(sp, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public async Task<IEnumerable<UserMasterModel>> getUserManagementDetailsById(int userManagement_ID, int TPACustomerID)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@UserID", userManagement_ID);
                    param.Add("@TPACustomerID", TPACustomerID);
                    string sp = "USP_getUserManagementDataByID";
                    var result = await db.QueryAsync<UserMasterModel>(sp, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }


        public async Task<IEnumerable<SuccesModel>> SubmitUpdateAgentDetails(MS_Agent MS_Agent)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@AgentId", MS_Agent.AgentID);
                    param.Add("@AgentCODE", MS_Agent.AgentCODE);
                    param.Add("@AgentName", MS_Agent.AgentName);
                    param.Add("@LocationType", MS_Agent.LocationType);
                    param.Add("@Center", MS_Agent.Center);
                    param.Add("@Location", MS_Agent.Location);
                    param.Add("@CreatedBy", MS_Agent.CreatedBy);
                    param.Add("@action", MS_Agent.action);
                    param.Add("@IsActive", MS_Agent.IsActive);

                    string sp = "USP_submitAgentDetails";
                    var result = await db.QueryAsync<SuccesModel>(sp, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public async Task<IEnumerable<MS_Agent>> getAgentDetailsById(int AgentID)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@AgentId", AgentID);
                    
                    string sp = "USP_getAgentDetailsById";
                    var result = await db.QueryAsync<MS_Agent>(sp, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public async Task<IEnumerable<MS_Agent>> getAllAgentDetails()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
                {
                    string sp = "USP_getAllAgentDetails";
                    var result = await db.QueryAsync<MS_Agent>(sp, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }


    }
}
