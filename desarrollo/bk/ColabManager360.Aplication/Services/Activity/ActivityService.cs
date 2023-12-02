using ColabManager360.Domain.Common.Responses;
using ColabManager360.Domain.Entities.Activity;
using ColabManager360.Domain.Entities.Activity.Requests;
using ColabManager360.Domain.Entities.Activity.Responses;
using ColabManager360.Domain.Entities.Common;
using ColabManager360.Domain.Entities.Common.Requests;
using ColabManager360.Domain.Entities.Common.Responses;
using ColabManager360.Domain.Interfaces.Activity;

namespace ColabManager360.Aplication.Services.Activity
{
    internal class ActivityService: IActivityService
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<List<Holiday>> HolidayList()
        {
            var response = await _activityRepository.HolidayList();
            return response;
        }

        public async Task<BaseResponse<CreateHolidayResponse>> CreateHoliday(HolidayRequest request)
        {
            var response = await _activityRepository.CreateHoliday(request);

            return response;
        }

        public async Task<BaseResponse<CreateHolidayResponse>> EditHoliday(HolidayRequest request)
        {
            var response = await _activityRepository.EditHoliday(request);

            return response;
        }

        public async Task<List<Period>> PeriodList()
        {
            var response = await _activityRepository.PeriodList();
            return response;
        }

        public async Task<BaseResponse<CreatePeriodResponse>> CreatePeriod(PeriodRequest request)
        {
            var response = await _activityRepository.CreatePeriod(request);

            return response;
        }

        public async Task<BaseResponse<CreatePeriodResponse>> EditPeriod(EditPeriodRequest request)
        {
            var response = await _activityRepository.EditPeriod(request);
            return response;
        }

        public async Task<List<ActivityType>> ActivityTypeList()
        {
            var response = await _activityRepository.ActivityTypeList();
            return response;
        }

        public async Task<BaseResponse<CreateActivityTypeResponse>> CreateActivityType(ActivityTypeRequest request)
        {
            var response = await _activityRepository.CreateActivityType(request);

            return response;
        }

        public async Task<BaseResponse<CreateActivityTypeResponse>> EditActivityType(EditActivityTypeRequest request)
        {
            var response = await _activityRepository.EditActivityType(request);

            return response;
        }
    }
}
