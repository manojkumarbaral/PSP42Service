using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessService.Interface
{
    public interface IProductInfo
    {
        Task<IEnumerable<ProductListModel>> getProductList();
    }
}
