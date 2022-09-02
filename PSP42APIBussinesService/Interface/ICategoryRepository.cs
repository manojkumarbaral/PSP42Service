using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessService.Interface
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
    }
}
