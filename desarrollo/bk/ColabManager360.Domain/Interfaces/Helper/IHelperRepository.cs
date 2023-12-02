using ColabManager360.Domain.Entities.Activity.Responses;
using ColabManager360.Domain.Entities.Client;
using ColabManager360.Domain.Entities.Common;
using ColabManager360.Domain.Entities.Common.Requests;
using ColabManager360.Domain.Entities.Helper.Responses;

namespace ColabManager360.Domain.Interfaces.Helper
{
    public interface IHelperRepository
    {
        Task<AccountListResponse> AccountLists();
        Task<List<ActivityType>> GetCompanyActivityTypeList(int request);
        Task<List<CompanyService>> GetCompanyServicesList(int request);
        Task<List<Country>> GetCountries();
        Task<List<Ubigeo>> GetDepartments();
        Task<List<Ubigeo>> GetDistricts(string DepartmentCode, string ProvinceCode);
        Task<List<MasterDetailTable>> GetMasterList(MasterDetailTableRequest request);
        Task<List<PeriodWeekResponse>> GetPeriodWeekList();
        Task<List<Ubigeo>> GetProvinces(string DepartmentCode);
        Task<List<ServiceType>> GetServiceTypes();
    }
}
