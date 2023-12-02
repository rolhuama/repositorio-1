using ColabManager360.Domain.Common.Responses;
using ColabManager360.Domain.Entities.Auth.Requests;
using ColabManager360.Domain.Entities.Auth.Responses;
using ColabManager360.Domain.Entities.Business;
using ColabManager360.Domain.Entities.Business.Requests;
using ColabManager360.Domain.Entities.Business.Responses;
using ColabManager360.Domain.Entities.Client;
using ColabManager360.Domain.Entities.Client.Requests;
using ColabManager360.Domain.Entities.Client.Responses;
using ColabManager360.Domain.Entities.Collaborator.Requests;
using ColabManager360.Domain.Entities.Collaborator.Responses;
using ColabManager360.Domain.Entities.Security.Models;
using ColabManager360.Domain.Entities.Security.Requests;
using ColabManager360.Domain.Entities.Security.Responses;
using ColabManager360.Domain.Interfaces.Security;

namespace ColabManager360.Aplication.Services.Security
{
    public class SecurityService: ISecurityService
    {
        private readonly ISecurityRepository _securityRepository;

        public SecurityService(ISecurityRepository securityRepository)
        {
            _securityRepository = securityRepository;
        }

        public async Task<UserResponse> Login(UserRequest request)
        {
            var response = await _securityRepository.Login(request);

            return response;
        }

        public async Task<UserResponse> LoginGoogle(GoogleCredentialsRequest request)
        {
            var response = await _securityRepository.LoginGoogle(request);

            return response;
        }
        public async Task<BaseResponse<List<UserListResponse>>> UserList()
        {
            var response = await _securityRepository.UserList();

            return response;
        }
        public async Task<List<Roles>> RoleList()
        {
            var response = await _securityRepository.RoleList();

            return response;
        }

        public async Task<BaseResponse<CreateUserResponse>> CreateUser(CreateUserRequest request)
        {
            var response = await _securityRepository.CreateUser(request);

            return response;
        }

        public async Task<BaseResponse<CreateUserResponse>> EditUser(CreateUserRequest request)
        {
            var response = await _securityRepository.EditUser(request);

            return response;
        }

        public async Task<List<Company>> CompanyList()
        {
            var response = await _securityRepository.CompanyList();

            return response;
        }

        public async Task<BaseResponse<CreateCompanyResponse>> CreateCompany(CompanyRequest request)
        {
            var response = await _securityRepository.CreateCompany(request);

            return response;
        }

        public async Task<BaseResponse<CreateCompanyResponse>> EditCompany(EditCompanyRequest request)
        {
            var response = await _securityRepository.EditCompany(request);

            return response;
        }

        public async Task<BaseResponse<CompanyInformationResponse>> CompanyInformation(int request)
        {
            var response = await _securityRepository.CompanyInformation(request);

            return response;
        }

        public async Task<BaseResponse<CreateCompanyServiceResponse>> CreateCompanyService(CreateCompanyServiceRequest request)
        {
            var response = await _securityRepository.CreateCompanyService(request);

            return response;
        }

        public async Task<BaseResponse<CreateCompanyServiceResponse>> EditCompanyService(EditCompanyServiceRequest request)
        {
            var response = await _securityRepository.EditCompanyService(request);

            return response;
        }

        public async Task<List<CostCenter>> CostCenterList()
        {
            var response = await _securityRepository.CostCenterList();

            return response;
        }

        public async Task<BaseResponse<CreateCostCenterResponse>> CreateCostCenter(CreateCostCenterRequest request)
        {
            var response = await _securityRepository.CreateCostCenter(request);

            return response;
        }
        public async Task<BaseResponse<CreateCostCenterResponse>> EditCostCenter(EditCostCenterRequest request)
        {
            var response = await _securityRepository.EditCostCenter(request);

            return response;
        }

        public async Task<List<CollaboratorListResponse>> CollaboratorList()
        {
            var response = await _securityRepository.CollaboratorList();

            return response;
        }

        public async Task<List<CollaboratorCompanyListResponse>> CollaboratorCompanyList(int request)
        {
            var response = await _securityRepository.CollaboratorCompanyList(request);

            return response;
        }

        public async Task<BaseResponse<AddCollaboratorCompanyResponse>> AddCollaboratorCompany(AddCollaboratorCompanyRequest request)
        {
            var response = await _securityRepository.AddCollaboratorCompany(request);

            return response;
        }

        public async Task<BaseResponse<AddCollaboratorCompanyResponse>> EditCollaboratorCompany(EditCollaboratorCompanyRequest request)
        {
            var response = await _securityRepository.EditCollaboratorCompany(request);

            return response;
        }

        public async Task<BaseResponse<string>> DeleteCollaboratorCompany(AddCollaboratorCompanyRequest request)
        {
            var response = await _securityRepository.DeleteCollaboratorCompany(request);

            return response;
        }

        public async Task<List<WorkArea>> WorkAreaList()
        {
            var response = await _securityRepository.WorkAreaList();

            return response;
        }

        public async Task<BaseResponse<CreateWorkAreaResponse>> CreateWorkArea(CreateWorkAreaRequest request)
        {
            var response = await _securityRepository.CreateWorkArea(request);

            return response;
        }
        public async Task<BaseResponse<CreateWorkAreaResponse>> EditWorkArea(EditWorkAreaRequest request)
        {
            var response = await _securityRepository.EditWorkArea(request);

            return response;
        }

        public async Task<List<WorkAreaTeam>> WorkAreaTeamList()
        {
            var response = await _securityRepository.WorkAreaTeamList();

            return response;
        }

        public async Task<BaseResponse<CreateWorkAreaTeamResponse>> CreateWorkAreaTeam(CreateWorkAreaTeamRequest request)
        {
            var response = await _securityRepository.CreateWorkAreaTeam(request);

            return response;
        }
        public async Task<BaseResponse<CreateWorkAreaTeamResponse>> DeleteWorkAreaTeam(EditWorkAreaTeamRequest request)
        {
            var response = await _securityRepository.DeleteWorkAreaTeam(request);

            return response;
        }

        public async Task<BaseResponse<WorkInfoResponse>> WorkInfo(int request)
        {
            var response = await _securityRepository.WorkInfo(request);

            return response;
        }


        public async Task<BaseResponse<WorkInfoResponse>> EditWorkInfo(WorkInfoRequest request)
        {
            var response = await _securityRepository.EditWorkInfo(request);

            return response;
        }

    }
}
