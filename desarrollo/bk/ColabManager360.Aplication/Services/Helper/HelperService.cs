using ColabManager360.Domain.Entities.Activity.Responses;
using ColabManager360.Domain.Entities.Client;
using ColabManager360.Domain.Entities.Common;
using ColabManager360.Domain.Entities.Common.Requests;
using ColabManager360.Domain.Entities.Helper.Responses;
using ColabManager360.Domain.Interfaces.Helper;

namespace ColabManager360.Aplication.Services.Helper
{
    public class HelperService : IHelperService
    {
        private readonly IHelperRepository _HelperRepository;

        public HelperService(IHelperRepository helperRepository)
        {
            _HelperRepository = helperRepository;
        }
        public async Task<AccountListResponse> AccountLists()
        {

            var response = await _HelperRepository.AccountLists();

            return response;

        }
        public async Task<List<Ubigeo>> GetDepartments() {
            var response = await _HelperRepository.GetDepartments();

            return response;

        }
        public async Task<List<Ubigeo>> GetProvinces(string DepartmentCode) {
            var response = await _HelperRepository.GetProvinces(DepartmentCode);

            return response;

        }
        public async Task<List<Ubigeo>> GetDistricts(string DepartmentCode, string ProvinceCode) {
            var response = await _HelperRepository.GetDistricts(DepartmentCode, ProvinceCode);

            return response;

        }
        public async Task<List<Country>> GetCountries()
        {
            var response = await _HelperRepository.GetCountries();

            return response;

        }

        public async Task<List<MasterDetailTable>> GetMasterList(MasterDetailTableRequest request)
        {
            var response = await _HelperRepository.GetMasterList(request);

            return response;

        }

        public async Task<List<ServiceType>> GetServiceTypes()
        {
            var response = await _HelperRepository.GetServiceTypes();

            return response;

        }

        public async Task<List<CompanyService>> GetCompanyServicesList(int request)
        {
            var response = await _HelperRepository.GetCompanyServicesList(request);

            return response;

        }

        public async Task<List<ActivityType>> GetCompanyActivityTypeList(int request)
        {
            var response = await _HelperRepository.GetCompanyActivityTypeList(request);

            return response;

        }

        public async Task<List<PeriodWeekResponse>> GetPeriodWeekList()
        {
            var response = await _HelperRepository.GetPeriodWeekList();

            return response;

        }
    }
}
