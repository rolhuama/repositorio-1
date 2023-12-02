using ColabManager360.Aplication.Services.Security;
using ColabManager360.Domain.Common.Responses;
using ColabManager360.Domain.Entities.Business.Requests;
using ColabManager360.Domain.Entities.Client.Requests;
using ColabManager360.Domain.Entities.Client.Responses;
using ColabManager360.Domain.Entities.Collaborator.Requests;
using ColabManager360.Domain.Entities.Security.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ColabManager360.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ISecurityService _securityService;

        public AdminController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet]
        [Route("UserList")]
        public async Task<IActionResult> UserList()
        {
            var response = await _securityService.UserList();

            if (response != null)
            {
              
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpGet]
        [Route("RoleList")]
        public async Task<IActionResult> RoleList()
        {
            var response = await _securityService.RoleList();

            if (response != null)
            {

                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            var response = await _securityService.CreateUser(request);

            if (response != null)
            {

                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPatch]
        [Route("EditUser")]
        public async Task<IActionResult> EditUser(CreateUserRequest request)
        {
            var response = await _securityService.EditUser(request);

            if (response != null)
            {

                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpGet]
        [Route("CompanyList")]
        public async Task<IActionResult> CompanyList()
        {
            var response = await _securityService.CompanyList();

            if (response != null)
            {

                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("CreateCompany")]
        public async Task<IActionResult> CreateCompany(CompanyRequest request)
        {
            var response = await _securityService.CreateCompany(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("EditCompany")]
        public async Task<IActionResult> EditCompany(EditCompanyRequest request)
        {
            var response = await _securityService.EditCompany(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpGet]
        [Route("Company/Information/{companyId}")]
        public async Task<IActionResult> Information(int companyId)
        {
            var response = new BaseResponse<CompanyInformationResponse>();

            try
            {
                response = await _securityService.CompanyInformation(companyId);

                response.Success = true;
                response.StatusCode = 200;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.StatusCode = 400;
                response.Message = ex.Message;
                return BadRequest(response);
            }


        }

        [HttpPost]
        [Route("Company/Services/Create")]
        public async Task<IActionResult> CreateCompanyService(CreateCompanyServiceRequest request)
        {
            var response = await _securityService.CreateCompanyService(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("Company/Services/Edit")]
        public async Task<IActionResult> EditCompanyService(EditCompanyServiceRequest request)
        {
            var response = await _securityService.EditCompanyService(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpGet]
        [Route("CostCenter/List")]
        public async Task<IActionResult> CostCenterList()
        {
            var response = await _securityService.CostCenterList();

            if (response != null)
            {

                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("CostCenter/Create")]
        public async Task<IActionResult> CreateCostCenter(CreateCostCenterRequest request)
        {
            var response = await _securityService.CreateCostCenter(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("CostCenter/Edit")]
        public async Task<IActionResult> EditCostCenter(EditCostCenterRequest request)
        {
            var response = await _securityService.EditCostCenter(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpGet]
        [Route("Collaborator/List")]
        public async Task<IActionResult> CollaboratorList()
        {
            var response = await _securityService.CollaboratorList();

            if (response != null)
            {

                return Ok(response);
            }

            return Unauthorized();
        }


        [HttpGet]
        [Route("Collaborator/Company/List/{CollabolatorId}")]
        public async Task<IActionResult> CollaboratorCompanyList(int CollabolatorId)
        {
            var response = await _securityService.CollaboratorCompanyList(CollabolatorId);

            if (response != null)
            {

                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("Collaborator/Company/Add")]
        public async Task<IActionResult> AddCollaboratorCompany(AddCollaboratorCompanyRequest request)
        {
            var response = await _securityService.AddCollaboratorCompany(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }


        [HttpPost]
        [Route("Collaborator/Company/Edit")]
        public async Task<IActionResult> EditCollaboratorCompany(EditCollaboratorCompanyRequest request)
        {
            var response = await _securityService.EditCollaboratorCompany(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("Collaborator/Company/Delete")]
        public async Task<IActionResult> DeleteCollaboratorCompany(AddCollaboratorCompanyRequest request)
        {
            var response = await _securityService.DeleteCollaboratorCompany(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }


        [HttpGet]
        [Route("Work-Area/List")]
        public async Task<IActionResult> WorkAreaList()
        {
            var response = await _securityService.WorkAreaList();

            if (response != null)
            {

                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("Work-Area/Create")]
        public async Task<IActionResult> CreateWorkArea(CreateWorkAreaRequest request)
        {
            var response = await _securityService.CreateWorkArea(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("Work-Area/Edit")]
        public async Task<IActionResult> EditWorkArea(EditWorkAreaRequest request)
        {
            var response = await _securityService.EditWorkArea(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpGet]
        [Route("Work-Area-Team/List")]
        public async Task<IActionResult> WorkAreaTeamList()
        {
            var response = await _securityService.WorkAreaTeamList();

            if (response != null)
            {

                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("Work-Area-Team/Create")]
        public async Task<IActionResult> CreateWorkAreaTeam(CreateWorkAreaTeamRequest request)
        {
            var response = await _securityService.CreateWorkAreaTeam(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("Work-Area-Team/Delete")]
        public async Task<IActionResult> DeleteWorkAreaTeam(EditWorkAreaTeamRequest request)
        {
            var response = await _securityService.DeleteWorkAreaTeam(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpGet]
        [Route("Work-info/{CollaboratorId}")]
        public async Task<IActionResult> WorkInfo(int CollaboratorId)
        {
            var response = await _securityService.WorkInfo(CollaboratorId);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPatch]
        [Route("Work-info/Edit")]
        public async Task<IActionResult> EditWorkInfo(WorkInfoRequest request)
        {
            var response = await _securityService.EditWorkInfo(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }


    }
}
