using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessService.Interface;
using BusinessEntities;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppiCore.Controllers
{
    [Route("api/[controller]")]
    public class MenuController : Controller
    {
        private IMenuBusiness MenuBusiness;
        public MenuController(IMenuBusiness _MenuBusiness)
        {
            this.MenuBusiness = _MenuBusiness;
          
        }
        [HttpGet("getMenuItems")]
        public async Task<IActionResult> getMenuItems()
        {
            var res = await MenuBusiness.getMenuItems();
            return Json(res);
        }
        [HttpGet("getSubMenuItems")]
        public async Task<IActionResult> getSubMenuItems()
        {
            var res = await MenuBusiness.getSubMenuItems();
            return Json(res);
        }
    }
}
