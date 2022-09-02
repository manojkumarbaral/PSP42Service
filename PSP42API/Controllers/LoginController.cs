using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessEntities;
using BusinessService.Interface;
using DATA.EF;
using BusinessEntities.LoginModel;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppiCore.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private ILogin Logininter;
        private readonly ApplicationDBContext ApplicationDBContext;
        public LoginController(ILogin _Login,
            ApplicationDBContext _ApplicationDBContext)
        {
            this.Logininter = _Login;
            this.ApplicationDBContext = _ApplicationDBContext;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginModel Loginvalue)
        {
            var res = await Logininter.Login(Loginvalue);
            return Json(res);
        }
        [HttpGet("userExpire")]
        public async Task<ActionResult> userExpire(string UserID)
        {
            var res = await Logininter.userExpire(UserID);
            return Json(res);
        }
        [HttpGet("getCompanyDetails")]
        public async Task<ActionResult> getCompanyDetails()
        {
            var res = await Logininter.getCompanyDetails();
            return Json(res);
        }
    }
}
