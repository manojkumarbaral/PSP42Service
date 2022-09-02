using BusinessEntities;
using BusinessService.Interface;
using DAL;
using Dapper;
using DATA.EF;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessService.Logic
{
    public class MenuBusinessService : IMenuBusiness
    {
        
        public DataLayer dl;
        private readonly ApplicationDBContext ApplicationDBContext;
        public MenuBusinessService(ApplicationDBContext _ApplicationDBContext)
        {
            this.ApplicationDBContext = _ApplicationDBContext;
            dl = new DataLayer();
        }
        
        //public IEnumerable<MS_MenuTable> getMenuItems()
        //{
           
        //    var res = ApplicationDBContext.MS_MenuTable.ToArray();
        //    return res;
        //}
        //public IEnumerable<MS_SubMenuTable> getSubMenuItems()
        //{
        //    var res = ApplicationDBContext.MS_SubMenuTable.ToArray();
        //    return res;
        //}

        public async Task<IEnumerable<MS_MenuTable>> getMenuItems()
        {
            using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
            {
                DynamicParameters param = new DynamicParameters();

                string sp = "USP_GetSubmenu";
                var result = await db.QueryAsync<MS_MenuTable>(sp, CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IEnumerable<MS_SubMenuTable>> getSubMenuItems()
        {
            using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
            {
                DynamicParameters param = new DynamicParameters();

                string sp = "USP_SubMenuTable";
                var result = await db.QueryAsync<MS_SubMenuTable>(sp, CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
