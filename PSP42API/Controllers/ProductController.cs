using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessService.Interface;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppiCore.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductInfo IProductInfo;
        public ProductController(IProductInfo _IProductInfo)
        {
            this.IProductInfo = _IProductInfo;
        }
        [HttpGet("getProductList")]
        public async Task<IActionResult> getProductList()
        {
            var res = await IProductInfo.getProductList();
            return Json(res);
        }
    }
}
