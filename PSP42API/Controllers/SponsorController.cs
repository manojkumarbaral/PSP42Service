using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessEntities.Sponsor;
using BusinessService.Interface;
using Microsoft.Extensions.Configuration;
using System.IO;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppiCore.Controllers
{
    [Route("api/[controller]")]
    public class SponsorController : Controller
    {
        private readonly string AppDirectory;
        private IConfiguration _Configuration;
        private ISponsorInterface SponsorInterface;
        public SponsorController(ISponsorInterface _SponsorInterface, IConfiguration Configuration)
        {
            this.SponsorInterface = _SponsorInterface;
            this._Configuration = Configuration;
            AppDirectory = _Configuration.GetSection("FileServerPath").GetSection("SponsorFilePath").Value;
        }
        [HttpPost("SubmitSponsorCreation")]
        public async Task<IActionResult> SubmitSponsorCreation([FromBody]SponsorSubmit SponsorSubmit)
        {
            var res = await SponsorInterface.SubmitSponsorCreation(SponsorSubmit);
            foreach (var res1 in res)
            {
                if (res1.isSuccess == true)
                {
                    if (SponsorSubmit.customerCode != string.Empty)
                    {
                        if (!Directory.Exists(AppDirectory + SponsorSubmit.customerCode + "\\SPONSOR_" + res1.SponsorTID + "_" + SponsorSubmit.EIDNumber+ "\\Members"))
                        {
                            Directory.CreateDirectory(AppDirectory + SponsorSubmit.customerCode + "\\SPONSOR_" + res1.SponsorTID + "_" + SponsorSubmit.EIDNumber + "\\Members");
                        }

                        if (!Directory.Exists(AppDirectory + SponsorSubmit.customerCode + "\\SPONSOR_" + res1.SponsorTID + "_" + SponsorSubmit.EIDNumber + "\\Photos"))
                        {
                            Directory.CreateDirectory(AppDirectory + SponsorSubmit.customerCode + "\\SPONSOR_" + res1.SponsorTID + "_" + SponsorSubmit.EIDNumber + "\\Photos");
                        }
                    }
                }
            }
                
            return Json(res);
        }

        [HttpGet("getSponsorDocumentList")]
        public async Task<IActionResult> getSponsorDocumentList(string sponsorTID)
        {
            var res = await SponsorInterface.getSponsorDocumentList(sponsorTID);
            return Json(res);
        }
        
        [HttpGet("getSponsorCheck")]
        public async Task<IActionResult> getSponsorCheck(string UID)
        {
            var res = await SponsorInterface.getSponsorCheck(UID);
            return Ok(res);
        }
    }
}
