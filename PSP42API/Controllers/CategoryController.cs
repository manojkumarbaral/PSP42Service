using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessService.Interface;
using BusinessEntities;
using DATA.EF;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppiCore.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private ICategoryRepository categoryRepository2;
        private readonly ApplicationDBContext ApplicationDBContext;
        public CategoryController(ICategoryRepository categoryRepository,
            ApplicationDBContext _ApplicationDBContext)
        {
            this.categoryRepository2 = categoryRepository;
            this.ApplicationDBContext = _ApplicationDBContext;
        }
        [HttpGet("GetCategories")]
        public async Task<IActionResult> Get()
        {
            List<Category> categories = categoryRepository2.GetCategories();
            return Ok(categories);
        }

        [HttpGet("GetCompanyDetails")]
        public IEnumerable<MS_Company> GetCompanyDetails()
        {
            var res = ApplicationDBContext.MS_Company.ToArray();
            return res;
        }
        [HttpGet("GetCustomerDetails")]
        public IEnumerable<MS_Customer> GetCustomerDetails()
        {
            var res = ApplicationDBContext.MS_Customer.ToArray();
            return res;
        }
    }
}
