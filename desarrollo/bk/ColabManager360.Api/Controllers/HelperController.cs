using ColabManager360.Aplication.Services.Activity;
using ColabManager360.Aplication.Services.Helper;
using ColabManager360.Aplication.Services.Security;
using ColabManager360.Domain.Entities.Client.Responses;
using ColabManager360.Domain.Entities.Common.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace ColabManager360.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        private readonly IHelperService _HelperService;
        private readonly ISecurityService _securityService;

        public HelperController(IHelperService helperService, ISecurityService securityService)
        {
            _HelperService = helperService;
            _securityService = securityService;
        }

        //[AllowAnonymous]
        [OutputCache(PolicyName = "AccountLists")]
        [HttpGet]
        [Route("AccountLists")]
        public async Task<IActionResult> AccountLists()
        {
            var response = await _HelperService.AccountLists();

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [OutputCache(PolicyName = "Departments")]
        [HttpGet]
        [Route("Departments")]
        public async Task<IActionResult> Departments()
        {
            var response = await _HelperService.GetDepartments();

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [OutputCache(PolicyName = "Provinces")]
        [HttpGet]
        [Route("Provinces")]
        public async Task<IActionResult> Provinces(string DepartmentCode)
        {
            var response = await _HelperService.GetProvinces(DepartmentCode);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [OutputCache(PolicyName = "Districts")]
        [HttpGet]
        [Route("Districts")]
        public async Task<IActionResult> Districts(string DepartmentCode, string ProvinceCode)
        {
            var response = await _HelperService.GetDistricts(DepartmentCode, ProvinceCode);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [OutputCache(PolicyName = "Countries")]
        [HttpGet]
        [Route("Countries")]
        public async Task<IActionResult> Countries()
        {
            var response = await _HelperService.GetCountries();

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [OutputCache(PolicyName = "MasterTableList")]
        [HttpGet]
        [Route("MasterTable/{TableName}/{TableCode}")]
        public async Task<IActionResult> MasterTableList(string TableName, string TableCode)
        {
            var request = new MasterDetailTableRequest() { TableName = TableName, TableCode = TableCode };

            var response = await _HelperService.GetMasterList(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpGet]
        [Route("Company/List")]
        public async Task<IActionResult> CompanyList()
        {
            var response = await _securityService.CompanyList();
           

            if (response != null)
            {
                var responseList = (from company in response
                                    select new CompanyResponse
                                    {
                                        Id = company.Id,
                                        LegalName = company.LegalName,
                                        CommercialName = company.CommercialName
                                    }).ToList();

                return Ok(responseList);
            }

            return Unauthorized();
        }

        [OutputCache(PolicyName = "ServiceTypes")]
        [HttpGet]
        [Route("Services/Types/List")]
        public async Task<IActionResult> ServiceTypesList()
        {
            var response = await _HelperService.GetServiceTypes();

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }


        [OutputCache(PolicyName = "CompanyServicesList")]
        [HttpGet]
        [Route("Company/Services/List/{CompanyId}")]
        public async Task<IActionResult> CompanyServicesList(int CompanyId)
        {
            var response = await _HelperService.GetCompanyServicesList(CompanyId);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [OutputCache(PolicyName = "CompanyActivityTypeList")]
        [HttpGet]
        [Route("Company/ActivityType/List/{CompanyId}")]
        public async Task<IActionResult> CompanyActivityTypeList(int CompanyId)
        {
            var response = await _HelperService.GetCompanyActivityTypeList(CompanyId);

            if (response != null)
            {

                return Ok(response);
            }

            return Unauthorized();
        }

        
        [OutputCache(PolicyName = "PeriodWeekList")]
        [HttpGet]
        [Route("Period/Week/List")]
        public async Task<IActionResult> PeriodWeekList()
        {
            var response = await _HelperService.GetPeriodWeekList();

            if (response != null)
            {

                return Ok(response);
            }

            return Unauthorized();
        }
    }
}
