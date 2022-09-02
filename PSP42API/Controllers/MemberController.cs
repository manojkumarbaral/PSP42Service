using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessService.Interface;
using BusinessEntities;
using BusinessEntities.Member;
using Microsoft.Extensions.Configuration;
using System.IO;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppiCore.Controllers
{
    [Route("api/[controller]")]
    public class MemberController : Controller
    {
        private readonly string AppDirectory;
        private IConfiguration _Configuration;
        private IMember IMember;
        public MemberController(IMember _IMember, IConfiguration Configuration)
        {
            this.IMember = _IMember;
            this._Configuration = Configuration;
            AppDirectory = _Configuration.GetSection("FileServerPath").GetSection("SponsorFilePath").Value;
        }
        [HttpPost("getMemberList")]
        public async Task<IActionResult> getMemberList([FromBody] MemberSearchModel MemberSearch)
        {
            var res = await IMember.getMemberList(MemberSearch);
            return Ok(res);
        }

        [HttpPost("SubmitMemberCreation")]
        public async Task<IActionResult> SubmitMemberCreation([FromBody]SubmitFormMember MemberSubmit)
        {
            var res = await IMember.SubmitMemberCreation(MemberSubmit);
            foreach (var res1 in res)
            {
                if (res1.isSuccess == true)
                {
                    if (MemberSubmit.customerCode != string.Empty)
                    {
                        if (!Directory.Exists(AppDirectory + MemberSubmit.customerCode + "\\SPONSOR_" + MemberSubmit.sponsorTID + "_" + MemberSubmit.sponsorEIDNumber + "\\Members"))
                        {
                            Directory.CreateDirectory(AppDirectory + MemberSubmit.customerCode + "\\SPONSOR_" + MemberSubmit.sponsorTID + "_" + MemberSubmit.sponsorEIDNumber + "\\Members");
                        }

                        if (!Directory.Exists(AppDirectory + MemberSubmit.customerCode + "\\SPONSOR_" + MemberSubmit.sponsorTID + "_" + MemberSubmit.sponsorEIDNumber + "\\Photos"))
                        {
                            Directory.CreateDirectory(AppDirectory + MemberSubmit.customerCode + "\\SPONSOR_" + MemberSubmit.sponsorTID + "_" + MemberSubmit.sponsorEIDNumber + "\\Photos");
                        }
                    }
                }
            }

            return Json(res);
        }
        [HttpGet("getMemberDetailsById")]
        public async Task<IActionResult> getMemberDetailsById(int member_ID)
        {
            var res = await IMember.getMemberDetailsByID(member_ID);
            return Ok(res);
        }
        [HttpGet("DeleteMember")]
        public async Task<IActionResult> DeleteMember(int member_ID)
        {
            var res = await IMember.DeleteMember(member_ID);
            return Ok(res);
        }

    }
}
