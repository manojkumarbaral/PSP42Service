using BusinessEntities;
using BusinessEntities.LoginModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessService.Interface
{
    public interface ILogin
    {
        Task<IEnumerable<UserDetailsData>> Login(LoginModel Logincred);
        Task<IEnumerable<SuccesModel>> userExpire(string UserCred);
        Task<IEnumerable<CompanyDetails>> getCompanyDetails();
    }
}
