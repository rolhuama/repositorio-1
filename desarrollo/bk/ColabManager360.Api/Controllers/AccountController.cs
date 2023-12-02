using ColabManager360.Aplication.Services.Account;
using ColabManager360.Aplication.Services.Activity;
using ColabManager360.Aplication.Services.Security;
using ColabManager360.Domain.Common.Responses;
using ColabManager360.Domain.Entities.Account.Requests;
using ColabManager360.Domain.Entities.Account.Responses;
using ColabManager360.Domain.Entities.Activity.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ColabManager360.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ISecurityService _securityService;


        public AccountController(IAccountService accountService, ISecurityService securityService)
        {
            _accountService = accountService;
            _securityService = securityService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var response = new BaseResponse<RegisterResponse>();

            try
            {
                response = await _accountService.Register(request);

                response.Success=true;
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

        [HttpGet]
        [Route("Information/{personId}")]
        public async Task<IActionResult> Information(string personId)
        {
            var response = new BaseResponse<InformationResponse>();

            try
            {
                response = await _accountService.Information(personId);

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

        [HttpGet]
        [Route("MenuList/{UserId}")]
        public async Task<IActionResult> MenuList(string UserId)
        {
            var response = new BaseResponse<MenuListResponse>();

            try
            {
                response = await _accountService.MenuList(UserId);

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

        [HttpGet]
        [Route("Company/List/{personId}")]
        public async Task<IActionResult> CollaboratorCompanyList(string personId)
        {
            var person  = await _accountService.Information(personId);

            var response = await _securityService.CollaboratorCompanyList(person.Data.CollaboratorId);

            if (response != null)
            {

                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("Company/Daily-Activity/Register")]
        public async Task<IActionResult> CompanyDaylyActivityCreate(DailyActivityRequest request)
        {
         

            var response = await _accountService.CompanyDaylyActivityCreate(request);

            if (response != null)
            {

                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("Company/Daily-Activity/List")]
        public async Task<IActionResult> CompanyDaylyActivityList(DailyActivityListRequest request)
        {


            var response = await _accountService.CompanyDaylyActivityList(request);

            if (response != null)
            {

                return Ok(response);
            }

            return Unauthorized();
        }





    }
}
