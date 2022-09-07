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
using Microsoft.Extensions.Logging;

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
                    param.Add("@tpaCustomerID", MS_Agent.tpaCustomerID);

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
        
        public async Task<IEnumerable<SuccesModel>> SubmitUpdateBrokerMasterDetails(MS_Broker MS_Broker)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@BrokerCode", MS_Broker.BrokerCode);
                    param.Add("@BrokerName", MS_Broker.BrokerName);
                    param.Add("@Broker_Trade_Lic_No", MS_Broker.Broker_Trade_Lic_No);
                    param.Add("@Broker_Tel", MS_Broker.Broker_Tel);
                    param.Add("@Broker_Email", MS_Broker.Broker_Email);
                    param.Add("@CallCenter_GenEnquiryPhNo", MS_Broker.CallCenter_GenEnquiryPhNo);
                    param.Add("@Broker_Address_Country_ID", MS_Broker.Broker_Address_Country_ID);
                    param.Add("@Broker_Address_State_ID", MS_Broker.Broker_Address_State_ID);
                    param.Add("@Broker_Address_City_ID", MS_Broker.Broker_Address_City_ID);
                    param.Add("@Broker_Address_Street1", MS_Broker.Broker_Address_Street1);
                    param.Add("@Broker_Address_Street2", MS_Broker.Broker_Address_Street2);
                    param.Add("@action", MS_Broker.action);
                    param.Add("@CreatedBy", MS_Broker.CreatedBy);
                    param.Add("@Broker_ID", MS_Broker.Broker_ID);
                    param.Add("@IsActive", MS_Broker.IsActive);
                    
                    string sp = "USP_submitUpdateBrokerMasterDetails";
                    var result = await db.QueryAsync<SuccesModel>(sp, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public async Task<IEnumerable<MS_Broker>> getAllBrokerMasterDetails()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
                {
                    string sp = "USP_getAllBrokerMasterDetails";
                    var result = await db.QueryAsync<MS_Broker>(sp, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public async Task<IEnumerable<MS_Broker>> getBrokerMasterDetailsById(int broker_ID)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Broker_ID", broker_ID);

                    string sp = "USP_getBrokerMasterDetailsById";
                    var result = await db.QueryAsync<MS_Broker>(sp, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public async Task<IEnumerable<SuccesModel>> SubmitUpdateBrokerBranchDetails(MS_Branch MS_Branch)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@AgentID", MS_Branch.AgentID);
                    param.Add("@Broker_ID", MS_Branch.Broker_ID);
                    param.Add("@CompanyId", MS_Branch.CompanyId);
                    param.Add("@BranchCode", MS_Branch.BranchCode);
                    param.Add("@BranchName", MS_Branch.BranchName);
                    param.Add("@BranchAddress", MS_Branch.BranchAddress);
                    param.Add("@Country_ID", MS_Branch.Country_ID);
                    param.Add("@State_ID", MS_Branch.State_ID);
                    param.Add("@City_ID", MS_Branch.City_ID);
                    param.Add("@OfficePhone", MS_Branch.OfficePhone);
                    param.Add("@CCPhone", MS_Branch.CCPhone);
                    param.Add("@OperationAdminAcc_Dep_Phone", MS_Branch.OperationAdminAcc_Dep_Phone);
                    param.Add("@Email", MS_Branch.Email);
                    param.Add("@BranchOpeningTime", MS_Branch.BranchOpeningTime);
                    param.Add("@BranchClosingTime", MS_Branch.BranchClosingTime);
                    param.Add("@action", MS_Branch.action);
                    param.Add("@CreatedBy", MS_Branch.CreatedBy);
                    param.Add("@IsActive", MS_Branch.IsActive);
                    string sp = string.Empty;
                    if (MS_Branch.type == "agent")
                    {
                        sp = "USP_submitUpdateAgentBranchDetails";
                    }
                    else
                    {
                        sp = "USP_submitUpdateBrokerBranchDetails";
                    }

                    var result = await db.QueryAsync<SuccesModel>(sp, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public async Task<IEnumerable<MS_Branch>> getAllBrokerBranchDetails()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
                {
                    string sp = "USP_getAllDataBrokerBranch";
                    var result = await db.QueryAsync<MS_Branch>(sp, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public async Task<IEnumerable<MS_Branch>> getBrokerBranchDetailsById(int Branch_ID)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Branch_ID", Branch_ID);

                    string sp = "USP_getAllDataBrokerBranchByID";
                    var result = await db.QueryAsync<MS_Branch>(sp, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public async Task<IEnumerable<MS_Branch>> getAgentBranchDetailsById(int Branch_ID)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Branch_ID", Branch_ID);

                    string sp = "USP_getAllDataAgentBranchByID";
                    var result = await db.QueryAsync<MS_Branch>(sp, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public async Task<IEnumerable<MS_Branch>> getAllAgentBranchDetails()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
                {
                    string sp = "USP_getAllDataAgentBranch";
                    var result = await db.QueryAsync<MS_Branch>(sp, commandType: CommandType.StoredProcedure);
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
