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

namespace ColabManager360.Domain.Interfaces.Security
{
    public interface ISecurityRepository
    {
        Task<BaseResponse<AddCollaboratorCompanyResponse>> AddCollaboratorCompany(AddCollaboratorCompanyRequest request);
        Task<List<CollaboratorCompanyListResponse>> CollaboratorCompanyList(int request);
        Task<List<CollaboratorListResponse>> CollaboratorList();
        Task<BaseResponse<CompanyInformationResponse>> CompanyInformation(int request);
        Task<List<Company>> CompanyList();
        Task<List<CostCenter>> CostCenterList();
        Task<BaseResponse<CreateCompanyResponse>> CreateCompany(CompanyRequest request);
        Task<BaseResponse<CreateCompanyServiceResponse>> CreateCompanyService(CreateCompanyServiceRequest request);
        Task<BaseResponse<CreateCostCenterResponse>> CreateCostCenter(CreateCostCenterRequest request);    
        Task<BaseResponse<CreateUserResponse>> CreateUser(CreateUserRequest request);
        Task<BaseResponse<CreateWorkAreaResponse>> CreateWorkArea(CreateWorkAreaRequest request);   
        Task<BaseResponse<CreateWorkAreaTeamResponse>> CreateWorkAreaTeam(CreateWorkAreaTeamRequest request);
        Task<BaseResponse<string>> DeleteCollaboratorCompany(AddCollaboratorCompanyRequest request);
        Task<BaseResponse<CreateWorkAreaTeamResponse>> DeleteWorkAreaTeam(EditWorkAreaTeamRequest request);
        Task<BaseResponse<AddCollaboratorCompanyResponse>> EditCollaboratorCompany(EditCollaboratorCompanyRequest request);
        Task<BaseResponse<CreateCompanyResponse>> EditCompany(EditCompanyRequest request);
        Task<BaseResponse<CreateCompanyServiceResponse>> EditCompanyService(EditCompanyServiceRequest request);
        Task<BaseResponse<CreateCostCenterResponse>> EditCostCenter(EditCostCenterRequest request);
        Task<BaseResponse<CreateUserResponse>> EditUser(CreateUserRequest request);
        Task<BaseResponse<CreateWorkAreaResponse>> EditWorkArea(EditWorkAreaRequest request);
        Task<BaseResponse<WorkInfoResponse>> EditWorkInfo(WorkInfoRequest request);
        Task<UserResponse> Login(UserRequest request);
        Task<UserResponse> LoginGoogle(GoogleCredentialsRequest request);
        Task<List<Roles>> RoleList();
        Task<BaseResponse<List<UserListResponse>>> UserList();
        Task<List<WorkArea>> WorkAreaList();
        Task<List<WorkAreaTeam>> WorkAreaTeamList();
        Task<BaseResponse<WorkInfoResponse>> WorkInfo(int request);
    }
}
