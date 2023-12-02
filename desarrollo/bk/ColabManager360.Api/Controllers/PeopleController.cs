using ColabManager360.Aplication.Services.Activity;
using ColabManager360.Domain.Entities.Activity.Requests;
using ColabManager360.Domain.Entities.Common.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ColabManager360.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IActivityService _activityService;
      

        public PeopleController(IActivityService activityService)
        {
            _activityService = activityService;
          
        }

        [HttpGet]
        [Route("Holiday/List")]
        public async Task<IActionResult> HolidayList()
        {
            var response = await _activityService.HolidayList();

            if (response != null)
            {

                return Ok(response);
            }

            return Unauthorized();
        }


        [HttpPost]
        [Route("Holiday/Create")]
        public async Task<IActionResult> CreateHoliday(HolidayRequest request)
        {
            var response = await _activityService.CreateHoliday(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("Holiday/Edit")]
        public async Task<IActionResult> EditHoliday(HolidayRequest request)
        {
            var response = await _activityService.EditHoliday(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpGet]
        [Route("Period/List")]
        public async Task<IActionResult> PeriodList()
        {
            var response = await _activityService.PeriodList();

            if (response != null)
            {

                return Ok(response);
            }

            return Unauthorized();
        }


        [HttpPost]
        [Route("Period/Create")]
        public async Task<IActionResult> CreatePeriody(PeriodRequest request)
        {
            var response = await _activityService.CreatePeriod(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("Period/Edit")]
        public async Task<IActionResult> EditPeriod(EditPeriodRequest request)
        {
            var response = await _activityService.EditPeriod(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpGet]
        [Route("ActivityType/List")]
        public async Task<IActionResult> ActivityTypeList()
        {
            var response = await _activityService.ActivityTypeList();

            if (response != null)
            {

                return Ok(response);
            }

            return Unauthorized();
        }


        [HttpPost]
        [Route("ActivityType/Create")]
        public async Task<IActionResult> CreateActivityType(ActivityTypeRequest request)
        {
            var response = await _activityService.CreateActivityType(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("ActivityType/Edit")]
        public async Task<IActionResult> EditActivityType(EditActivityTypeRequest request)
        {
            var response = await _activityService.EditActivityType(request);

            if (response != null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }



    }
}
