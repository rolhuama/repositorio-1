using ColabManager360.Domain.Common.Responses;
using ColabManager360.Domain.Entities.Account.Requests;
using ColabManager360.Domain.Entities.Account.Responses;
using ColabManager360.Domain.Entities.Activity.Requests;
using ColabManager360.Domain.Entities.Activity.Responses;
using ColabManager360.Domain.Interfaces.Account;

namespace ColabManager360.Aplication.Services.Account
{
    internal class AccountService: IAccountService
    {
        private readonly IAccountRepository _AccountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _AccountRepository = accountRepository;
        }

        public async Task<BaseResponse<RegisterResponse>> Register(RegisterRequest request)
        {
            return await _AccountRepository.Register(request);
        }

        public async Task<BaseResponse<InformationResponse>> Information(string request)
        {
            return await _AccountRepository.Information(request);
        }

        public async Task<BaseResponse<MenuListResponse>> MenuList(string request)
        {
            return await _AccountRepository.MenuList(request);
        }

        public async Task<BaseResponse<DailyActivityResponse>> CompanyDaylyActivityCreate(DailyActivityRequest request)
        {
            return await _AccountRepository.CompanyDaylyActivityCreate(request);
        }

        public async Task<BaseResponse<DailyActivityListResponse>> CompanyDaylyActivityList(DailyActivityListRequest request)
        {
            return await _AccountRepository.CompanyDaylyActivityList(request);
        }

    }
}
