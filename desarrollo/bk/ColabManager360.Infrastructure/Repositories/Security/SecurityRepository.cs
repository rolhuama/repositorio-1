using ColabManager360.Domain.Entities.Auth.Requests;
using ColabManager360.Domain.Entities.Auth.Responses;
using ColabManager360.Domain.Interfaces.Security;
using Google.Apis.Auth;
using ColabManager360.Infrastructure.Repositories.Identity;
using ColabManager360.Domain.Entities.Security.Models;
using ColabManager360.Domain.Common.Responses;
using ColabManager360.Domain.Entities.Security.Responses;
using ColabManager360.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ColabManager360.Domain.Entities.Security.Requests;
using ColabManager360.Domain.Entities.Client;
using ColabManager360.Domain.Entities.Client.Requests;
using ColabManager360.Domain.Entities.Client.Responses;
using AutoMapper;
using ColabManager360.Domain.Entities.Business;
using ColabManager360.Domain.Entities.Business.Requests;
using ColabManager360.Domain.Entities.Business.Responses;
using ColabManager360.Domain.Entities.Collaborator.Responses;
using ColabManager360.Domain.Entities.Collaborator.Requests;
using ColabManager360.Domain.Entities.Collaborator;

namespace ColabManager360.Infrastructure.Repositories.Security
{
    internal class SecurityRepository : ISecurityRepository
    {

        //private readonly HttpClient _httpClient;
        private readonly IIdentityService _IdentityService;
        private readonly ApplicationDbContext _DB;
        private readonly IMapper _mapper;

        public SecurityRepository(IIdentityService identityService, ApplicationDbContext DB, IMapper mapper)
        {
            //_httpClient = new HttpClient();
            _IdentityService = identityService;
            _DB = DB;
            _mapper = mapper;
        }

        public async Task<UserResponse> Login(UserRequest request)
        {

            var response = await _IdentityService.PasswordSignInAsync(request.UserName, request.Password);

            return response;

        }

        public async Task<UserResponse> LoginGoogle(GoogleCredentialsRequest request)
        {

            var response = new UserResponse();

            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string> { request.clientId }
                };

                var paytoad = await GoogleJsonWebSignature.ValidateAsync(request.credential, settings);

                response.Name = paytoad.Name;
                response.Email = paytoad.Email;
                response.FamilyName = paytoad.FamilyName;
                response.GivenName = paytoad.GivenName;
                response.Picture = paytoad.Picture;

                var userDB = await _IdentityService.FindByNameAsync(response.Email);

                if (userDB?.Email != null)
                {

                    //response.Role = userDB.Role;
                    //response.IsRegistered = userDB.IsRegistered;
                    //response .Id = userDB.Id;
                    //response.PersonId = userDB.PersonId;
                    response = userDB;
                    response.Picture = paytoad.Picture;
                    response.Name = paytoad.Name;

                }
                else
                {
                    var user = new Users()
                    {
                        UserName = response.Email,
                        Email = response.Email,
                        Picture = response.Picture

                    };

                    var result = await _IdentityService.CreateAsync(user);
                    response.Role = result.Role;
                    response.Id = result.Id;


                }


            }
            catch (Exception)
            {
                response = null;

            }

            return response;

        }
        public async Task<BaseResponse<List<UserListResponse>>> UserList()
        {
            var response = new BaseResponse<List<UserListResponse>>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new List<UserListResponse>()
            };

            var users = await (from user in _DB.Users
                               join person in _DB.PersonInformation on user.Person.Uid equals person.Uid into personGroup
                               from person in personGroup.DefaultIfEmpty()
                               join userRole in _DB.UserRoles on user.Id equals userRole.UserId
                               join role in _DB.Roles on userRole.RoleId equals role.Id
                               select new UserListResponse
                               {
                                   UserName = user.UserName,
                                   Email = user.Email,
                                   LockoutEnabled = user.LockoutEnabled,
                                   FirstName1 = person.FirstName1,
                                   FirstName2 = person.FirstName2,
                                   LastName1 = person.LastName1,
                                   LastName2 = person.LastName2,
                                   RoleId = role.Id,
                                   RoleName = role.Name,
                                   IsRegistered = (user.Person != null)
                               }).AsNoTracking().ToListAsync();

            if (users.Any())
            {
                response.Data = users;
            }


            return response;

        }

        public async Task<List<Roles>> RoleList()
        {

            return await _DB.Roles.AsNoTracking().ToListAsync();

        }

        public async Task<BaseResponse<CreateUserResponse>> CreateUser(CreateUserRequest request)
        {
            var response = new BaseResponse<CreateUserResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new CreateUserResponse()
            };

            var user = new Users()
            {
                UserName = request.Email,
                Email = request.Email,
                LockoutEnabled = false

            };

            var result = await _IdentityService.CreateAsync(user, request.RoleId);

            if (result.Id != null)
            {
                response.Data.Id = result.Id;
            }

            else
            {
                response.StatusCode = 400;
                response.Message = "No se pudo crear el usuario, por favor verifique que el correo no este registrado.";
            }

            return response;

        }

        public async Task<BaseResponse<CreateUserResponse>> EditUser(CreateUserRequest request)
        {
            var response = new BaseResponse<CreateUserResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new CreateUserResponse()
            };

            var user = new Users()
            {
                UserName = request.Email,
                Email = request.Email,
                LockoutEnabled = request.LockoutEnabled

            };

            var result = await _IdentityService.EditUserAsync(user, request.RoleId);

            if (result.Id != null)
            {
                response.Data.Id = result.Id;
            }
            else
            {
                response.StatusCode = 400;
                response.Message = "No se puede editar este usuario.";
            }

            return response;

        }

        public async Task<List<Company>> CompanyList()
        {

            return await _DB.Companies.AsNoTracking().ToListAsync();

        }

        public async Task<BaseResponse<CreateCompanyResponse>> CreateCompany(CompanyRequest request)
        {
            var response = new BaseResponse<CreateCompanyResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new CreateCompanyResponse()
            };

            var item = _mapper.Map<Company>(request);

            var costCenter = await _DB.CostCenter.FirstOrDefaultAsync(i => i.Code == request.costCenterCode);

            item.CostCenter = costCenter;

            var result = await _DB.Companies.AddAsync(item);
            await _DB.SaveChangesAsync();

            if (result.IsKeySet)
            {
                response.Data.Id = result.Entity.Id;
            }
            else
            {
                response.StatusCode = 400;
                response.Message = "No se pudo crear, por favor verifique que los datos";
            }


            return response;

        }

        public async Task<BaseResponse<CreateCompanyResponse>> EditCompany(EditCompanyRequest request)
        {
            var response = new BaseResponse<CreateCompanyResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new CreateCompanyResponse()
            };

            try
            {

                await _DB.Database.BeginTransactionAsync();

                var item = _mapper.Map<Company>(request);

                var company = await _DB.Companies.Where(c => c.Id == item.Id).FirstOrDefaultAsync();
                var costCenter = await _DB.CostCenter.FirstOrDefaultAsync(i => i.Code == request.costCenterCode);

                if (company is not null)
                {
                    company.TaxIdentificationNumber = item.TaxIdentificationNumber;
                    company.LegalName = item.LegalName;
                    company.CommercialName = item.CommercialName;
                    company.FiscalAddress = item.FiscalAddress;
                    company.Country = item.Country;
                    company.EconomicSector = item.EconomicSector;
                    company.CostCenter = costCenter;
                    company.IsActive = item.IsActive;

                }
                else
                {
                    response.Success = false;
                    response.StatusCode = 400;
                    response.Message = "No se pudo modificar, por favor verifique que los datos sean correctos (ID).";
                }

                await _DB.SaveChangesAsync();

                await _DB.Database.CommitTransactionAsync();

            }
            catch (Exception ex)
            {
                await _DB.Database.RollbackTransactionAsync();

                response.Success = false;
                response.StatusCode = 500;
                response.Message = ex.Message;

            }

            return response;

        }


        public async Task<BaseResponse<CompanyInformationResponse>> CompanyInformation(int request)
        {
            var response = new BaseResponse<CompanyInformationResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new CompanyInformationResponse()
            };

            var info = await _DB.Companies.FirstOrDefaultAsync(i => i.Id == request);

            response.Data = _mapper.Map<CompanyInformationResponse>(info);


            return response;

        }

        public async Task<BaseResponse<CreateCompanyServiceResponse>> CreateCompanyService(CreateCompanyServiceRequest request)
        {
            var response = new BaseResponse<CreateCompanyServiceResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new CreateCompanyServiceResponse()
            };

            try
            {

                await _DB.Database.BeginTransactionAsync();

                var company = await _DB.Companies.FirstAsync(i => i.Id == request.CompanyId);
                var type = await _DB.ServiceTypes.FirstAsync(i => i.Id == request.TypeId);
                var costCenter = await _DB.CostCenter.FirstOrDefaultAsync(i => i.Code == request.CostCenterCode);

                var item = _mapper.Map<CompanyService>(request);

                item.Company = company;
                item.Type = type;
                item.CostCenter = costCenter;

                var result = await _DB.CompanyServices.AddAsync(item);

                await _DB.SaveChangesAsync();

                if (result.IsKeySet)
                {
                    response.Data.Id = result.Entity.Id;
                }
                else
                {
                    response.Success = false;
                    response.StatusCode = 400;
                    response.Message = "No se pudo crear, por favor verifique los datos ingresados.";
                }

                await _DB.Database.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await _DB.Database.RollbackTransactionAsync();
                response.Success = false;
                response.StatusCode = 400;
                response.Message = ex.Message;
            }


            return response;

        }

        public async Task<BaseResponse<CreateCompanyServiceResponse>> EditCompanyService(EditCompanyServiceRequest request)
        {
            var response = new BaseResponse<CreateCompanyServiceResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new CreateCompanyServiceResponse()
            };

            await _DB.Database.BeginTransactionAsync();

            var type = await _DB.ServiceTypes.FirstAsync(i => i.Id == request.TypeId);
            var costCenter = await _DB.CostCenter.FirstOrDefaultAsync(i => i.Code == request.CostCenterCode);

            var item = await _DB.CompanyServices.FirstOrDefaultAsync(i => i.Id == request.Id);


            if (item is not null)
            {
                item.Code = request.Code;
                item.Description = request.Description;
                item.Type = type;
                item.CostCenter = costCenter;
            }
            else
            {
                response.StatusCode = 400;
                response.Message = "No se pudo crear, por favor verifique los datos ingresados.";
            }

            await _DB.SaveChangesAsync();

            await _DB.Database.CommitTransactionAsync();

            return response;

        }

        public async Task<List<CostCenter>> CostCenterList()
        {

            return await _DB.CostCenter.AsNoTracking().ToListAsync();

        }

        public async Task<BaseResponse<CreateCostCenterResponse>> CreateCostCenter(CreateCostCenterRequest request)
        {
            var response = new BaseResponse<CreateCostCenterResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new CreateCostCenterResponse()
            };

            var item = _mapper.Map<CostCenter>(request);

            var result = await _DB.CostCenter.AddAsync(item);

            if (result.IsKeySet)
            {
                response.Data.Id = result.Entity.Id;
            }
            else
            {
                response.StatusCode = 400;
                response.Message = "No se pudo crear, por favor verifique que los datos";
            }

            await _DB.SaveChangesAsync();

            return response;

        }

        public async Task<BaseResponse<CreateCostCenterResponse>> EditCostCenter(EditCostCenterRequest request)
        {
            var response = new BaseResponse<CreateCostCenterResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new CreateCostCenterResponse()
            };

            try
            {

                await _DB.Database.BeginTransactionAsync();

                var item = await _DB.CostCenter.Where(c => c.Id == request.Id).FirstOrDefaultAsync();

                if (item is not null)
                {
                    item.Code = request.Code;
                    item.Description = request.Description;


                }
                else
                {
                    response.Success = false;
                    response.StatusCode = 400;
                    response.Message = "No se pudo modificar, por favor verifique que los datos sean correctos (ID).";
                }

                await _DB.SaveChangesAsync();

                await _DB.Database.CommitTransactionAsync();

            }
            catch (Exception ex)
            {
                await _DB.Database.RollbackTransactionAsync();

                response.Success = false;
                response.StatusCode = 500;
                response.Message = ex.Message;

            }

            return response;

        }

        public async Task<List<CollaboratorListResponse>> CollaboratorList()
        {

            var response = await (from colab in _DB.Collaborators
                                  join person in _DB.PersonInformation on colab.Person.Uid equals person.Uid
                                  into personGroup
                                  from person in personGroup.DefaultIfEmpty()
                                  select new CollaboratorListResponse
                                  {
                                      Id = colab.Id,
                                      PersonUid = colab.Person.Uid,
                                      EntelgyCode = person.EntelgyCode,
                                      FirstName1 = person.FirstName1,
                                      FirstName2 = person.FirstName2,
                                      LastName1 = person.LastName1,
                                      LastName2 = person.LastName2,
                                      WorkEmail = person.WorkEmail,
                                      Position = person.Position,
                                      WorkCellPhone = person.WorkCellPhone

                                  }).AsNoTracking().ToListAsync();

            return response;

        }

        public async Task<List<CollaboratorCompanyListResponse>> CollaboratorCompanyList(int request)
        {

            var response = await (from colab in _DB.Collaborators
                                  join person in _DB.PersonInformation on colab.Person.Uid equals person.Uid
                                  join colabCompany in _DB.CollaboratorCompanies on colab.Id equals colabCompany.CollaboratorId
                                  join company in _DB.Companies on colabCompany.CompanyId equals company.Id
                                  where colab.Id == request
                                  select new CollaboratorCompanyListResponse
                                  {
                                      CollaboratorId = colab.Id,
                                      CompanyId = company.Id,
                                      LegalName = company.LegalName,
                                      CommercialName = company.CommercialName,
                                      ClientPosition = colabCompany.ClientPosition


                                  }).AsNoTracking().ToListAsync();

            return response;

        }

        public async Task<BaseResponse<AddCollaboratorCompanyResponse>> AddCollaboratorCompany(AddCollaboratorCompanyRequest request)
        {
            var response = new BaseResponse<AddCollaboratorCompanyResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new AddCollaboratorCompanyResponse()
            };

            try
            {
                var item = _mapper.Map<CollaboratorCompany>(request);

                var result = await _DB.CollaboratorCompanies.AddAsync(item);

                await _DB.SaveChangesAsync();

                if (result.IsKeySet)
                {
                    response.Data.CollaboratorId = result.Entity.CollaboratorId;
                    response.Data.CompanyId = result.Entity.CompanyId;
                }
                else
                {
                    response.Success = false;
                    response.StatusCode = 400;
                    response.Message = "No se pudo agregar, por favor verifique que los datos";
                }



            }
            catch (Exception ex)
            {

                response.Success = false;
                response.StatusCode = 500;
                response.Message = ex.Message;
            }

            return response;

        }

        public async Task<BaseResponse<AddCollaboratorCompanyResponse>> EditCollaboratorCompany(EditCollaboratorCompanyRequest request)
        {
            var response = new BaseResponse<AddCollaboratorCompanyResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new AddCollaboratorCompanyResponse()
            };

            try
            {
                var item = _mapper.Map<CollaboratorCompany>(request);

                var result = _DB.CollaboratorCompanies.Update(item);

                await _DB.SaveChangesAsync();

                if (result.IsKeySet)
                {
                    response.Data.CollaboratorId = result.Entity.CollaboratorId;
                    response.Data.CompanyId = result.Entity.CompanyId;
                }
                else
                {
                    response.Success = false;
                    response.StatusCode = 400;
                    response.Message = "No se pudo agregar, por favor verifique que los datos";
                }



            }
            catch (Exception ex)
            {

                response.Success = false;
                response.StatusCode = 500;
                response.Message = ex.Message;
            }

            return response;

        }

        public async Task<BaseResponse<string>> DeleteCollaboratorCompany(AddCollaboratorCompanyRequest request)
        {
            var response = new BaseResponse<string>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = ""
            };

            try
            {

                var item = await _DB.CollaboratorCompanies.FirstOrDefaultAsync(i => i.CollaboratorId == request.CollaboratorId && i.CompanyId == request.CompanyId);

                if (item is not null)
                {
                    _DB.CollaboratorCompanies.Remove(item);
                    await _DB.SaveChangesAsync();

                    response.Data = "OK";

                }


            }
            catch (Exception ex)
            {

                response.Success = false;
                response.StatusCode = 500;
                response.Message = ex.Message;
            }

            return response;

        }


        public async Task<List<WorkArea>> WorkAreaList()
        {

            return await _DB.WorkAreas.AsNoTracking().ToListAsync();

        }

        public async Task<BaseResponse<CreateWorkAreaResponse>> CreateWorkArea(CreateWorkAreaRequest request)
        {
            var response = new BaseResponse<CreateWorkAreaResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new CreateWorkAreaResponse()
            };

            var item = _mapper.Map<WorkArea>(request);

            var result = await _DB.WorkAreas.AddAsync(item);

            await _DB.SaveChangesAsync();

            if (result.IsKeySet)
            {
                response.Data.Id = result.Entity.Id;
            }
            else
            {
                response.StatusCode = 400;
                response.Message = "No se pudo crear, por favor verifique que los datos";
            }



            return response;

        }

        public async Task<BaseResponse<CreateWorkAreaResponse>> EditWorkArea(EditWorkAreaRequest request)
        {
            var response = new BaseResponse<CreateWorkAreaResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new CreateWorkAreaResponse()
            };

            try
            {

                await _DB.Database.BeginTransactionAsync();

                var item = await _DB.WorkAreas.Where(c => c.Id == request.Id).FirstOrDefaultAsync();

                if (item is not null)
                {
                    item.Code = request.Code;
                    item.Name = request.Name;

                }
                else
                {
                    response.Success = false;
                    response.StatusCode = 400;
                    response.Message = "No se pudo modificar, por favor verifique que los datos sean correctos (ID).";
                }

                await _DB.SaveChangesAsync();

                await _DB.Database.CommitTransactionAsync();

            }
            catch (Exception ex)
            {
                await _DB.Database.RollbackTransactionAsync();

                response.Success = false;
                response.StatusCode = 500;
                response.Message = ex.Message;

            }

            return response;

        }


        public async Task<List<WorkAreaTeam>> WorkAreaTeamList()
        {

            return await _DB.WorkAreaTeams.AsNoTracking().ToListAsync();

        }

        public async Task<BaseResponse<CreateWorkAreaTeamResponse>> CreateWorkAreaTeam(CreateWorkAreaTeamRequest request)
        {
            var response = new BaseResponse<CreateWorkAreaTeamResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new CreateWorkAreaTeamResponse()
            };

            var item = _mapper.Map<WorkAreaTeam>(request);

            var result = await _DB.WorkAreaTeams.AddAsync(item);

            await _DB.SaveChangesAsync();

            if (result.IsKeySet)
            {
                response.Data.Id = result.Entity.Id;
            }
            else
            {
                response.StatusCode = 400;
                response.Message = "No se pudo crear, por favor verifique que los datos";
            }



            return response;

        }

        public async Task<BaseResponse<CreateWorkAreaTeamResponse>> DeleteWorkAreaTeam(EditWorkAreaTeamRequest request)
        {
            var response = new BaseResponse<CreateWorkAreaTeamResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new CreateWorkAreaTeamResponse()
            };

            try
            {

                await _DB.Database.BeginTransactionAsync();

                var item = await _DB.WorkAreaTeams.FirstOrDefaultAsync(i => i.Id == request.Id && i.WorkAreaId == request.WorkAreaId);

                if (item is not null)
                {

                    _DB.WorkAreaTeams.Remove(item);

                }

                await _DB.SaveChangesAsync();

                await _DB.Database.CommitTransactionAsync();

            }
            catch (Exception ex)
            {
                await _DB.Database.RollbackTransactionAsync();

                response.Success = false;
                response.StatusCode = 500;
                response.Message = ex.Message;

            }

            return response;

        }

        public async Task<BaseResponse<WorkInfoResponse>> WorkInfo(int request)
        {
            var response = new BaseResponse<WorkInfoResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new WorkInfoResponse()
            };

            var info = await _DB.Collaborators
                                .Include(i => i.Person)
                                .Include(i => i.WorkArea)
                                .Include(i => i.WorkAreaTeam)
                                .FirstOrDefaultAsync(i => i.Id == request);

            if (info is not null)
            {
                response.Data = _mapper.Map<WorkInfoResponse>(info);

                response.Data.Position = info.Person.Position;
            }




            return response;

        }

        public async Task<BaseResponse<WorkInfoResponse>> EditWorkInfo(WorkInfoRequest request)
        {
            var response = new BaseResponse<WorkInfoResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new WorkInfoResponse()
            };

            try
            {

                await _DB.Database.BeginTransactionAsync();

                var user = await _DB.Users.Include(i => i.Person).FirstOrDefaultAsync(i => i.Id == request.UserId);

                if (user is null)
                {

                    throw new ArgumentException("No se encontro Usuario!");

                }

                if (user.Person is null)
                {
                    throw new ArgumentException("No se encontro datos de Persona!");
                }

                var colab = await _DB.Collaborators.FirstOrDefaultAsync(i => i.Person.Uid == user.Person.Uid);

                if (colab is null)
                {
                    throw new ArgumentException("No se encontro datos de Colaborador!");
                }

                var workArea = await _DB.WorkAreas.FirstOrDefaultAsync(i => i.Id == request.WorkAreaId);
                var workAreaTeam = await _DB.WorkAreaTeams.FirstOrDefaultAsync(i => i.WorkAreaId == request.WorkAreaId && i.Id == request.WorkAreaTeamId);


                user.Person.Position = request.Position;
                colab.WorkArea = workArea;
                colab.WorkAreaTeam = workAreaTeam;


                await _DB.SaveChangesAsync();

                await _DB.Database.CommitTransactionAsync();

            }
            catch (Exception ex)
            {
                await _DB.Database.RollbackTransactionAsync();

                response.Success = false;
                response.StatusCode = 500;
                response.Message = ex.Message;

            }

            return response;

        }

    }
}
