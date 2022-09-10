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
    public class MasterController : Controller
    {

        private IMasterInterface MasterInterface;
        public MasterController(IMasterInterface _MasterInterface)
        {
            this.MasterInterface = _MasterInterface;
        }

        [HttpGet("getCountryCode")]
        public async Task<ActionResult> getCountryCode()
        {
            var res = await MasterInterface.getCountryCode();
            return Json(res);
        }
        [HttpGet("getMemberType")]
        public async Task<ActionResult> getMemberType()
        {
            var res = await MasterInterface.getMemberType();
            return Json(res);
        }

        [HttpGet("getGenderMaster")]
        public async Task<ActionResult> getGenderMaster()
        {
            var res = await MasterInterface.getGenderMaster();
            return Json(res);
        }

        [HttpGet("getVisaEmirateMaster")]
        public async Task<ActionResult> getVisaEmirateMaster(int iCountryID)
        {
            var res = await MasterInterface.getVisaEmirateMaster(iCountryID);
            return Json(res);
        }
        [HttpGet("getCountryMaster")]
        public async Task<ActionResult> getCountryMaster()
        {
            var res = await MasterInterface.getCountryMaster();
            return Json(res);
        }
        [HttpGet("getResidentialEmirateMaster")]
        public async Task<ActionResult> getResidentialEmirateMaster()
        {
            var res = await MasterInterface.getResidentialEmirateMaster();
            return Json(res);
        }
        [HttpGet("getSalaryRange")]
        public async Task<ActionResult> getSalaryRange()
        {
            var res = await MasterInterface.getSalaryRange();
            return Json(res);
        }
        [HttpGet("getRelationshiptotheSponsor")]
        public async Task<ActionResult> getRelationshiptotheSponsor()
        {
            var res = await MasterInterface.getRelationshiptotheSponsor();
            return Json(res);
        }

        [HttpGet("getUsertype")]
        public async Task<ActionResult> getUsertype()
        {
            var res = await MasterInterface.getUsertype();
            return Json(res);
        }
        [HttpGet("getAgent")]
        public async Task<ActionResult> getAgent()
        {
            var res = await MasterInterface.getAgent();
            return Json(res);
        }
        [HttpGet("getBroker")]
        public async Task<ActionResult> getBroker()
        {
            var res = await MasterInterface.getBroker();
            return Json(res);
        }
        [HttpGet("getBranch")]
        public async Task<ActionResult> getBranch()
        {
            var res = await MasterInterface.getBranch();
            return Json(res);
        }
        [HttpGet("getTPACustomer")]
        public async Task<ActionResult> getTPACustomer()
        {
            var res = await MasterInterface.getTPACustomer();
            return Json(res);
        }
        [HttpGet("getUsermaster")]
        public async Task<ActionResult> getUsermaster()
        {
            var res = await MasterInterface.getUsermaster();
            return Json(res);
        }

        [HttpGet("getBrokerBranch")]
        public async Task<ActionResult> getBrokerBranch()
        {
            var res = await MasterInterface.getBrokerBranch();
            return Json(res);
        }

        [HttpGet("getAgentBranch")]
        public async Task<ActionResult> getAgentBranch()
        {
            var res = await MasterInterface.getAgentBranch();
            return Json(res);
        }
    }
}
