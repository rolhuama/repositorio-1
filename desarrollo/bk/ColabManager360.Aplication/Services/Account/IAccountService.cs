using ColabManager360.Domain.Common.Responses;
using ColabManager360.Domain.Entities.Account.Requests;
using ColabManager360.Domain.Entities.Account.Responses;
using ColabManager360.Domain.Entities.Activity.Requests;
using ColabManager360.Domain.Entities.Activity.Responses;

namespace ColabManager360.Aplication.Services.Account
{
    public interface IAccountService
    {
        Task<BaseResponse<DailyActivityResponse>> CompanyDaylyActivityCreate(DailyActivityRequest request);
        Task<BaseResponse<DailyActivityListResponse>> CompanyDaylyActivityList(DailyActivityListRequest request);
        Task<BaseResponse<InformationResponse>> Information(string request);
        Task<BaseResponse<MenuListResponse>> MenuList(string request);
        Task<BaseResponse<RegisterResponse>> Register(RegisterRequest request);
    }
}
