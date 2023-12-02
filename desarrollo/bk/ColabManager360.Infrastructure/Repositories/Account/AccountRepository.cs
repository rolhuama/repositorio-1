using AutoMapper;
using ColabManager360.Domain.Common.Responses;
using ColabManager360.Domain.Entities.Account;
using ColabManager360.Domain.Entities.Account.Requests;
using ColabManager360.Domain.Entities.Account.Responses;
using ColabManager360.Domain.Entities.Activity.Requests;
using ColabManager360.Domain.Entities.Activity.Responses;
using ColabManager360.Domain.Entities.Auth.Responses;
using ColabManager360.Domain.Entities.Collaborator;
using ColabManager360.Domain.Interfaces.Account;
using ColabManager360.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace ColabManager360.Infrastructure.Repositories.Account
{
    internal class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _DB;
        private readonly IMapper _mapper;

        public AccountRepository(ApplicationDbContext DBcontext, IMapper mapper)
        {
            _DB = DBcontext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<RegisterResponse>> Register(RegisterRequest request)
        {
            var response = new BaseResponse<RegisterResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new RegisterResponse()
            };

            try
            {
                await _DB.Database.BeginTransactionAsync();

                var personRegister = await _DB.PersonInformation.Where(u => u.WorkEmail == request.WorkEmail).FirstOrDefaultAsync();
                var documet = await _DB.DocumentTypes.Where(i => i.Id == request.DocumentTypeId).FirstAsync();

                if (personRegister != null)
                {
                    personRegister.DocumentType = documet;
                    personRegister.DocumentNumber = request.DocumentNumber;
                    personRegister.FirstName1 = request.FirstName1;
                    personRegister.FirstName2 = request.FirstName2;
                    personRegister.LastName1 = request.LastName1;
                    personRegister.LastName2 = request.LastName2;
                    personRegister.Birthday = request.Birthday;
                    personRegister.Nationality = request.Nationality;
                    personRegister.Gender = request.Gender;
                    personRegister.HasChildren = request.HasChildren;
                    personRegister.Address = request.Address;
                    personRegister.ReferenceAddress = request.ReferenceAddress;
                    personRegister.Department = request.Department;
                    personRegister.Province = request.Province;
                    personRegister.District = request.District;
                    personRegister.Country = "PE";
                    personRegister.PersonalEmail = request.PersonalEmail;
                    personRegister.PersonalCellPhone = request.PersonalCellPhone;
                    personRegister.WorkEmail = request.WorkEmail;
                    personRegister.WorkCellPhone = request.WorkCellPhone;
                    personRegister.IsActive = 1;

                }
                else
                {

                    var person = new PersonInformation
                    {
                        DocumentType = documet,
                        DocumentNumber = request.DocumentNumber,
                        FirstName1 = request.FirstName1,
                        FirstName2 = request.FirstName2,
                        LastName1 = request.LastName1,
                        LastName2 = request.LastName2,
                        Birthday = request.Birthday,
                        Nationality = request.Nationality,
                        Gender = request.Gender,
                        HasChildren = request.HasChildren,
                        Address = request.Address,
                        ReferenceAddress = request.ReferenceAddress,
                        Department = request.Department,
                        Province = request.Province,
                        District = request.District,
                        Country = "PE",
                        PersonalEmail = request.PersonalEmail,
                        PersonalCellPhone = request.PersonalCellPhone,
                        WorkEmail = request.WorkEmail,
                        WorkCellPhone = request.WorkCellPhone,
                        IsActive = 1

                    };

                    personRegister = person;

                    await _DB.PersonInformation.AddAsync(personRegister);

                    await _DB.Collaborators.AddAsync(new Collaborator { Person = personRegister, Transversal = false });
                }


                var user = await _DB.Users.Where(u => u.UserName == personRegister.WorkEmail).FirstOrDefaultAsync();

                if (user != null)
                {
                    user.Person = personRegister;

                }

                await _DB.SaveChangesAsync();

                response.Data.Uid = personRegister.Uid.ToString();

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

        public async Task<BaseResponse<InformationResponse>> Information(string request)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var response = new BaseResponse<InformationResponse>
                {
                    Success = true,
                    StatusCode = 200,
                    Message = "OK",
                    Data = new InformationResponse()
                };

                var info = await _DB.PersonInformation.AsNoTracking().Where(p => p.Uid.ToString() == request).Include(p => p.DocumentType).FirstOrDefaultAsync();

                if (info != null)
                {
                    var user = await _DB.Users.AsNoTracking().Where(p => p.Person.Uid == info.Uid).FirstAsync();

                    response.Data = _mapper.Map<InformationResponse>(info);
                    response.Data.User = _mapper.Map<UserResponse>(user);

                    response.Data.User.GivenName = $"{info.FirstName1} {info.FirstName2}";
                    response.Data.User.FamilyName = $"{info.LastName1} {info.LastName2}";
                    response.Data.User.IsRegistered = true;
                    response.Data.User.Position = info.Position;

                }

                var colab = await _DB.Collaborators.AsNoTracking().Where(p => p.Person.Uid.ToString() == request).FirstOrDefaultAsync();

                if (colab is not null)
                {
                    response.Data.CollaboratorId = colab.Id;
                }



                scope.Complete(); // Confirma la transacción
                return response;
            }

        }

        public async Task<BaseResponse<MenuListResponse>> MenuList(string request)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var response = new BaseResponse<MenuListResponse>
                {
                    Success = true,
                    StatusCode = 200,
                    Message = "OK",
                    Data = new MenuListResponse()
                };

                var roles = await (from user in _DB.Users
                                   join userRole in _DB.UserRoles on user.Id equals userRole.UserId
                                   join role in _DB.Roles on userRole.RoleId equals role.Id
                                   where user.Id == request
                                   select new
                                   {
                                       RoleId = role.Id,
                                       RoleName = role.Name,

                                   }).AsNoTracking().ToListAsync();

                var isAdmin = roles.Exists(role => role.RoleId == "ADMIN");

                if (isAdmin)
                {
                    // El usuario tiene el rol "ADMIN"
                    response.Data.Groups = await _DB.MenuGroup.AsNoTracking().ToListAsync();
                    response.Data.Links = await _DB.Menu.AsNoTracking().ToListAsync();
                }
                else
                {
                    // El usuario no tiene el rol "ADMIN"

                    var userRoles = await (from user in _DB.Users
                                           join userRole in _DB.UserRoles on user.Id equals userRole.UserId
                                           join role in _DB.Roles on userRole.RoleId equals role.Id
                                           where user.Id == request
                                           select role.Id).ToListAsync();

                    var menuIds = await (from menuRole in _DB.MenuRole
                                         where userRoles.Contains(menuRole.RoleId)
                                         select menuRole.MenuId).ToListAsync();

                    var menus = await _DB.Menu.AsNoTracking().Where(i => menuIds.Contains(i.Id)).ToListAsync();

                    var menuGroups = (from m in menus
                                      select m.GroupId).ToList();

                    var groups = await _DB.MenuGroup.AsNoTracking().Where(i => menuGroups.Contains(i.Id)).ToListAsync();

                    response.Data.Groups = groups;
                    response.Data.Links = menus;



                }

                scope.Complete(); // Confirma la transacción
                return response;
            }

        }

        public async Task<BaseResponse<DailyActivityResponse>> CompanyDaylyActivityCreate(DailyActivityRequest request)
        {

            var response = new BaseResponse<DailyActivityResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new DailyActivityResponse()
            };

            try
            {

                await _DB.Database.BeginTransactionAsync();

                var user = await _DB.Users.Include(i => i.Person).FirstOrDefaultAsync(i => i.Id == request.UserId);

                if (user is null)
                {
                    throw new ArgumentException("No existe usuario!");
                }

                var collaborator = await _DB.Collaborators.FirstOrDefaultAsync(i => i.Person.Uid == user.Person.Uid);


                if (collaborator is null)
                {
                    throw new ArgumentException("No existe colaborador!");
                }

                var company = await _DB.Companies.FirstOrDefaultAsync(i => i.Id == request.CompanyId);

                if (company is null)
                {
                    throw new ArgumentException("No existe cliente!");
                }


                var activitiesToDelete = await _DB.Activities.Where(i => i.Collaborator == collaborator && i.Company == company && i.Week== request.WeekNumber).ToArrayAsync();


                // Elimina los detalles asociados a las actividades
                var detailsToDelete = await _DB.ActivitiesDetail.Where(ad => activitiesToDelete.Contains(ad.Activity)).ToListAsync();
                _DB.ActivitiesDetail.RemoveRange(detailsToDelete);

                // Elimina las actividades
                _DB.RemoveRange(activitiesToDelete);


                var activityList = _mapper.Map<List<Domain.Entities.Activity.Activity>>(request.Activities);
                var period = await _DB.Periods.FirstOrDefaultAsync(i=> i.Year==request.Period.Year && i.Month==request.Period .Month );

                foreach (var activity in activityList)
                {
                    activity.Status = "REGISTRADO";
                    activity.Collaborator = collaborator;
                    activity.Company = company;
                    activity.Period = period;
                    activity.ActivityType = await _DB.ActivityTypes.FirstOrDefaultAsync(i => i.Id == activity.ActivityType.Id);

                    if (activity.ActivityType is null)
                    {
                        throw new ArgumentException("No existe tipo actividad!");
                    }

                    activity.CompanyService = await _DB.CompanyServices.FirstOrDefaultAsync(i => i.Id == activity.CompanyService.Id);

                    if (activity.CompanyService is null)
                    {
                        throw new ArgumentException("No existe tipo servicio / proyecto!");
                    }


                    foreach (var detail in activity.Detail)
                    {
                        detail.Activity = activity;
                        detail.Year = request.Period.Year;
                        //detail.Month = request.Period.Month;

                        if (detail.Month == request.Period.Month)
                        {
                            detail.Date = new DateTime(detail.Year, detail.Month, detail.Day, 0, 0, 0, DateTimeKind.Utc);
                        }


                    }

                    activity.Detail = activity.Detail.Where(i => i.Date != null).ToList();

                }



                await _DB.Activities.AddRangeAsync(activityList);

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


        public async Task<BaseResponse<DailyActivityListResponse>> CompanyDaylyActivityList(DailyActivityListRequest request)
        {

            var response = new BaseResponse<DailyActivityListResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new DailyActivityListResponse()
            };

            try
            {

                var activities = await (from activity in _DB.Activities
                                        join colab in _DB.Collaborators on activity.Collaborator.Id equals colab.Id
                                        join user in _DB.Users on colab.Person.Uid equals user.Person.Uid
                                        where
                                        user.Id == request.UserId
                                        && activity.Company.Id==request.CompanyId
                                        && activity.Week == request.Week
                                        select activity)
                                        .Include(activity=> activity.Detail)
                                        .Include(activity => activity.Company)
                                        .Include(activity => activity.ActivityType)
                                        .Include(activity => activity.CompanyService)
                                        .ToListAsync();





                response.Data.Activities = _mapper.Map<List<ActivityRequest>>(activities); ;

            }
            catch (Exception ex)
            {



                response.Success = false;
                response.StatusCode = 500;
                response.Message = ex.Message;
            }



            return response;
        }

    }

}

