using ColabManager360.Domain.Common.Responses;
using ColabManager360.Domain.Entities.Activity;
using ColabManager360.Domain.Entities.Activity.Requests;
using ColabManager360.Domain.Entities.Activity.Responses;
using ColabManager360.Domain.Entities.Common;
using ColabManager360.Domain.Entities.Common.Requests;
using ColabManager360.Domain.Entities.Common.Responses;

namespace ColabManager360.Aplication.Services.Activity
{
    public interface IActivityService
    {
        Task<List<ActivityType>> ActivityTypeList();
        Task<BaseResponse<CreateActivityTypeResponse>> CreateActivityType(ActivityTypeRequest request);
        Task<BaseResponse<CreateHolidayResponse>> CreateHoliday(HolidayRequest request);
        Task<BaseResponse<CreatePeriodResponse>> CreatePeriod(PeriodRequest request);
        Task<BaseResponse<CreateActivityTypeResponse>> EditActivityType(EditActivityTypeRequest request);
        Task<BaseResponse<CreateHolidayResponse>> EditHoliday(HolidayRequest request);
        Task<BaseResponse<CreatePeriodResponse>> EditPeriod(EditPeriodRequest request);
        Task<List<Holiday>> HolidayList();
        Task<List<Period>> PeriodList();
    }
}
