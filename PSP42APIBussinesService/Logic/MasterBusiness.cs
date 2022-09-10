using BusinessEntities;
using BusinessService.Interface;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using BusinessEntities.MasterModel;

namespace BusinessService.Logic
{
    public class MasterBusiness : IMasterInterface
    {
        public DataLayer dl;
        public MasterBusiness()
        {
            dl = new DataLayer();
        }
        public async Task<IEnumerable<tbl_MST_CountryMaster>> getCountryCode()
        {
            using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
            {
                string sp = "USP_CountryMaster";
                var result = await db.QueryAsync<tbl_MST_CountryMaster>(sp, commandType: CommandType.StoredProcedure);
                return result;
            }


        }
        public async Task<IEnumerable<MS_MemberType>> getMemberType()
        {
            using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
            {
                string sp = "USP_getMemberType";
                var result = await db.QueryAsync<MS_MemberType>(sp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IEnumerable<MS_GenderMaster>> getGenderMaster()
        {
            using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
            {
                string sp = "USP_GenderMaster";
                var result = await db.QueryAsync<MS_GenderMaster>(sp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IEnumerable<MS_VisaEmirate>> getVisaEmirateMaster(int iCountryID)
        {
            using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@CountryID",iCountryID);
                string sp = "USP_VisaEmirateMaster";
                var result = await db.QueryAsync<MS_VisaEmirate>(sp, param, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IEnumerable<MS_Country>> getCountryMaster()
        {
            using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
            {
                string sp = "USP_Country";
                var result = await db.QueryAsync<MS_Country>(sp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IEnumerable<MS_ResidentialEmirate>> getResidentialEmirateMaster()
        {
            using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
            {
                string sp = "USP_ResidentialEmirate";
                var result = await db.QueryAsync<MS_ResidentialEmirate>(sp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IEnumerable<MS_Salary>> getSalaryRange()
        {
            using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
            {
                string sp = "USP_getSalaryRange";
                var result = await db.QueryAsync<MS_Salary>(sp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IEnumerable<MS_RelationshiptotheSponsor>> getRelationshiptotheSponsor()
        {
            using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
            {
                string sp = "USP_getRelationshiptotheSponsor";
                var result = await db.QueryAsync<MS_RelationshiptotheSponsor>(sp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IEnumerable<MS_UserTypes>> getUsertype()
        {
            using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
            {
                string sp = "USP_getUsertype";
                var result = await db.QueryAsync<MS_UserTypes>(sp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IEnumerable<MS_Agent>> getAgent()
        {
            using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
            {
                string sp = "USP_getAgentDetails";
                var result = await db.QueryAsync<MS_Agent>(sp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IEnumerable<MS_Broker>> getBroker()
        {
            using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
            {
                string sp = "USP_getBrokerDetails";
                var result = await db.QueryAsync<MS_Broker>(sp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IEnumerable<MS_Branch>> getBranch()
        {
            using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
            {
                string sp = "USP_getBranchDetails";
                var result = await db.QueryAsync<MS_Branch>(sp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IEnumerable<MS_Customer>> getTPACustomer()
        {
            using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
            {
                string sp = "USP_getTPACustmer";
                var result = await db.QueryAsync<MS_Customer>(sp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IEnumerable<UserMasterModel>> getUsermaster()
        {
            using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
            {
                string sp = "USP_getUsermaster";
                var result = await db.QueryAsync<UserMasterModel>(sp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<MS_Branch>> getBrokerBranch()
        {
            using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
            {
                string sp = "USP_getBrokerBranch";
                var result = await db.QueryAsync<MS_Branch>(sp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<MS_Branch>> getAgentBranch()
        {
            using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
            {
                string sp = "USP_getAgentBranch";
                var result = await db.QueryAsync<MS_Branch>(sp, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
