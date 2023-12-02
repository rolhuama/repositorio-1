using AutoMapper;
using ColabManager360.Domain.Entities.Account;
using ColabManager360.Domain.Entities.Account.Responses;
using ColabManager360.Domain.Entities.Activity;
using ColabManager360.Domain.Entities.Activity.Requests;
using ColabManager360.Domain.Entities.Auth.Responses;
using ColabManager360.Domain.Entities.Business.Responses;
using ColabManager360.Domain.Entities.Client;
using ColabManager360.Domain.Entities.Client.Requests;
using ColabManager360.Domain.Entities.Client.Responses;
using ColabManager360.Domain.Entities.Collaborator;
using ColabManager360.Domain.Entities.Collaborator.Requests;
using ColabManager360.Domain.Entities.Common;
using ColabManager360.Domain.Entities.Common.Requests;
using ColabManager360.Domain.Entities.Security.Models;

namespace ColabManager360.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonInformation, InformationResponse>().ReverseMap();
            CreateMap<Users, UserResponse>().ReverseMap();

            CreateMap<Company, CompanyRequest>().ReverseMap();
            CreateMap<Company, EditCompanyRequest>().ReverseMap();
            CreateMap<Company, CompanyInformationResponse>().ReverseMap();

            CreateMap<Period, PeriodRequest>().ReverseMap();
            CreateMap<Period, EditPeriodRequest>().ReverseMap();

            CreateMap<ActivityType, ActivityTypeRequest>().ReverseMap();
            CreateMap<ActivityType, EditActivityTypeRequest>().ReverseMap();
            CreateMap<Activity, ActivityRequest>().ReverseMap();     
            CreateMap<ActivityType, DailyActivityTypeRequest>().ReverseMap();
            CreateMap<ActivityDetail, ActivityDetailRequest>().ReverseMap();

            CreateMap<CompanyService, CreateCompanyServiceRequest>().ReverseMap();
            CreateMap<CompanyService, DailyCompanyServiceRequest>().ReverseMap();

            CreateMap<CollaboratorCompany, AddCollaboratorCompanyRequest>().ReverseMap();

            CreateMap<Collaborator, WorkInfoResponse>().ReverseMap();
        }
    }
}
