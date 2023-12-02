using ColabManager360.Aplication.Services.Helper;
using ColabManager360.Aplication.Services.Reports;
using ColabManager360.Domain.Entities.Reports.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ColabManager360.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        private readonly IReportService _ReportService;

        public ReportController(IReportService reportService)
        {
            _ReportService = reportService;
        }



        [HttpPost]
        [Route("Company/Collaborator/daily-hours-input")]

        public async Task<IActionResult> DailyHoursInput(DailyHoursInputRequest request)
        {
            var response = await _ReportService.DailyHoursInput(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }




    }



}
