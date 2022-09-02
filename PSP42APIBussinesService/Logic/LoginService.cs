using BusinessEntities.LoginModel;
using BusinessService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Microsoft.Extensions.Configuration;
using Dapper;
using DATA.EF;
using BusinessEntities;

namespace BusinessService.Logic
{
    public class LoginService: ILogin
    {
        public DataLayer DL;
        private readonly ApplicationDBContext ApplicationDBContext;
        public LoginService(ApplicationDBContext _ApplicationDBContext)
        {
            this.ApplicationDBContext = _ApplicationDBContext;
            DL = new DataLayer();
        }
        public async Task<IEnumerable<UserDetailsData>> Login(LoginModel UserCred)
        {
            using (IDbConnection db = new SqlConnection(DL.GetConnectionString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserID", UserCred.UserID);
                param.Add("@Password", UserCred.password);
                string sp = "USP_LoginUser";
                var result = await db.QueryAsync<UserDetailsData>(sp, param, commandType: CommandType.StoredProcedure);
                return result;
            }

            
        }
        public async Task<IEnumerable<SuccesModel>> userExpire(string UserID)
        {
            using (IDbConnection db = new SqlConnection(DL.GetConnectionString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserID", UserID);
                string sp = "USP_userExpire";
                var result = await db.QueryAsync<SuccesModel>(sp, param, commandType: CommandType.StoredProcedure);
                return result;
            }


        }
        public async Task<IEnumerable<CompanyDetails>> getCompanyDetails()
        {
            using (IDbConnection db = new SqlConnection(DL.GetConnectionString()))
            {
                
                string sp = "USP_Companydetails";
                var result = await db.QueryAsync<CompanyDetails>(sp, commandType: CommandType.StoredProcedure);
                return result;
            }


        }
    }
}
