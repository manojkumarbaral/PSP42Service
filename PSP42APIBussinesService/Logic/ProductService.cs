using BusinessEntities;
using BusinessService.Interface;
using DAL;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessService.Logic
{
    public class ProductService: IProductInfo
    {
        public DataLayer dl;
        public ProductService()
        {
            dl = new DataLayer();
        }

        public async Task<IEnumerable<ProductListModel>> getProductList()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(dl.GetConnectionString()))
                {
                    string sp = "USP_ProductListInfo";
                    var result = await db.QueryAsync<ProductListModel>(sp, commandType: CommandType.StoredProcedure);
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
