using BusinessEntities.Member;
using BusinessService.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessEntities;
using Microsoft.Extensions.Configuration;
using System.IO;
using BusinessEntities.MasterModel;

namespace WebAppiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private IUserManagementInterface IUserManagementInterface;
        public UserManagementController(IUserManagementInterface _IUserManagementInterface)
        {
            this.IUserManagementInterface = _IUserManagementInterface;
        }

        [HttpPost("SubmitUserManagementCreation")]
        public async Task<IActionResult> SubmitUserManagementCreation([FromBody] UserMasterModel UserMaster)
        {
            var res = await IUserManagementInterface.SubmitUserManagementCreation(UserMaster);
            
            return Ok(res);
        }
        [HttpGet("getUserManagementDetailsById")]
        public async Task<IActionResult> getUserManagementDetailsById(int userManagement_ID, int TPACustomerID)
        {
            var res = await IUserManagementInterface.getUserManagementDetailsById(userManagement_ID, TPACustomerID);
            return Ok(res);
        }

        [HttpPost("SubmitUpdateAgentDetails")]
        public async Task<IActionResult> SubmitUpdateAgentDetails([FromBody] MS_Agent MS_Agent)
        {
            var res = await IUserManagementInterface.SubmitUpdateAgentDetails(MS_Agent);

            return Ok(res);
        }
        [HttpGet("getAllAgentDetails")]
        public async Task<IActionResult> getAllAgentDetails()
        {
            var res = await IUserManagementInterface.getAllAgentDetails();
            return Ok(res);
        }
        [HttpGet("getAgentDetailsById")]
        public async Task<IActionResult> getAgentDetailsById(int agentID)
        {
            var res = await IUserManagementInterface.getAgentDetailsById(agentID);
            return Ok(res);
        }


        [HttpPost("SubmitUpdateBrokerMasterDetails")]
        public async Task<IActionResult> SubmitUpdateBrokerMasterDetails([FromBody] MS_Broker MS_Broker)
        {
            var res = await IUserManagementInterface.SubmitUpdateBrokerMasterDetails(MS_Broker);

            return Ok(res);
        }
        [HttpGet("getAllBrokerMasterDetails")]
        public async Task<IActionResult> getAllBrokerMasterDetails()
        {
            var res = await IUserManagementInterface.getAllBrokerMasterDetails();
            return Ok(res);
        }
        [HttpGet("getBrokerMasterDetailsById")]
        public async Task<IActionResult> getBrokerMasterDetailsById(int Broker_ID)
        {
            var res = await IUserManagementInterface.getBrokerMasterDetailsById(Broker_ID);
            return Ok(res);
        }


        [HttpPost("SubmitUpdateBranchDetails")]
        public async Task<IActionResult> SubmitUpdateBranchDetails([FromBody] MS_Branch MS_Branch)
        {
            var res = await IUserManagementInterface.SubmitUpdateBrokerBranchDetails(MS_Branch);

            return Ok(res);
        }
        [HttpGet("getAllBrokerBranchDetails")]
        public async Task<IActionResult> getAllBrokerBranchDetails()
        {
            var res = await IUserManagementInterface.getAllBrokerBranchDetails();
            return Ok(res);
        }
        [HttpGet("getBrokerBranchDetailsById")]
        public async Task<IActionResult> getBrokerBranchDetailsById(int Branch_ID)
        {
            var res = await IUserManagementInterface.getBrokerBranchDetailsById(Branch_ID);
            return Ok(res);
        }

        [HttpGet("getAllAgentBranchDetails")]
        public async Task<IActionResult> getAllAgentBranchDetails()
        {
            var res = await IUserManagementInterface.getAllAgentBranchDetails();
            return Ok(res);
        }
        [HttpGet("getAgentBranchDetailsById")]
        public async Task<IActionResult> getAgentBranchDetailsById(int AgentID)
        {
            var res = await IUserManagementInterface.getAgentBranchDetailsById(AgentID);
            return Ok(res);
        }   
    }
}
