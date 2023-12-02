using AutoMapper;
using ColabManager360.Domain.Common.Responses;
using ColabManager360.Domain.Entities.Activity;
using ColabManager360.Domain.Interfaces.Activity;
using ColabManager360.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ColabManager360.Domain.Entities.Activity.Requests;
using ColabManager360.Domain.Entities.Activity.Responses;
using ColabManager360.Infrastructure.Common;
using ColabManager360.Domain.Entities.Common;
using ColabManager360.Domain.Entities.Common.Responses;
using ColabManager360.Domain.Entities.Common.Requests;

namespace ColabManager360.Infrastructure.Repositories.Activity
{
    internal class ActivityRepository: IActivityRepository
    {
        private readonly ApplicationDbContext _DB;
        private readonly IMapper _mapper;

        public ActivityRepository(ApplicationDbContext dB, IMapper mapper)
        {
            _DB = dB;
            _mapper = mapper;
        }

        public async Task<List<Holiday>> HolidayList()
        {

            return await _DB.Holidays.AsNoTracking().ToListAsync();

        }

        public async Task<BaseResponse<CreateHolidayResponse>> CreateHoliday(HolidayRequest request)
        {
            var response = new BaseResponse<CreateHolidayResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new CreateHolidayResponse()
            };

            var item = _mapper.Map<Holiday>(request);

            item.days = Common.Utilities.CalculateDaysBetweenDates(item.StartDate, item.EndDate);

            var result = await _DB.Holidays.AddAsync(item);

            if (result.IsKeySet)
            {
                response.Data.Id = result.Entity.Id;
            }
            else
            {
                response.StatusCode = 400;
                response.Message = "No se pudo crear, por favor verifique que los datos esten correctos";
            }

            await _DB.SaveChangesAsync();

            return response;

        }

        public async Task<BaseResponse<CreateHolidayResponse>> EditHoliday(HolidayRequest request)
        {
            var response = new BaseResponse<CreateHolidayResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new CreateHolidayResponse()
            };

            var item = _mapper.Map<Holiday>(request);

            var bdEntity = await _DB.Holidays.Where(c => c.Id == item.Id).FirstOrDefaultAsync();

            if (bdEntity is not null)
            {
                bdEntity.Year = item.Year;
                bdEntity.Description = item.Description;
                bdEntity.StartDate  = item.StartDate;
                bdEntity.EndDate  = item.EndDate;

                bdEntity.days = Common.Utilities.CalculateDaysBetweenDates(bdEntity.StartDate, bdEntity.EndDate);

            }
            else
            {
                response.StatusCode = 400;
                response.Message = "No se pudo modificar, por favor verifique que los datos sean correctos (ID).";
            }

            await _DB.SaveChangesAsync();

            return response;

        }

        public async Task<List<Period>> PeriodList()
        {

            return await _DB.Periods.AsNoTracking().Include(i=>i.StateMasterTable).ToListAsync();

        }

        public async Task<BaseResponse<CreatePeriodResponse>> CreatePeriod(PeriodRequest request)
        {
            var response = new BaseResponse<CreatePeriodResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new CreatePeriodResponse()
            };

            var item = _mapper.Map<Period>(request);

            item.Id = item.Year.ToString("0000") + item.Month.ToString("00");

            item.StartDate = new DateTime(item.Year, item.Month, 1);
            item.EndDate = item.StartDate.Value.LastDayOfMonth();
                    

            item.MaximumDays = Utilities.CalculateBusinessDaysInMonth(item.Year, item.Month);

            if (request.MaximumHours==0)
            {
                item.MaximumHours = item.MaximumDays * 8;
            }

            var result = await _DB.Periods.AddAsync(item);

            if (result.IsKeySet)
            {
                response.Data.Id = result.Entity.Id;
            }
            else
            {
                response.StatusCode = 400;
                response.Message = "No se pudo crear, por favor verifique que los datos esten correctos";
            }

            await _DB.SaveChangesAsync();

            return response;

        }

        public async Task<BaseResponse<CreatePeriodResponse>> EditPeriod(EditPeriodRequest request)
        {
            var response = new BaseResponse<CreatePeriodResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new CreatePeriodResponse()
            };

            var item = _mapper.Map<Period>(request);

            var bdEntity = await _DB.Periods.Where(c => c.Id == item.Id).FirstOrDefaultAsync();

            if (bdEntity is not null)
            {
                //bdEntity.Year = item.Year;
                //bdEntity.Month = item.Month;
                bdEntity.Description = item.Description;
                bdEntity.State = item.State;
                bdEntity.MaximumHours = item.MaximumHours;

                bdEntity.StartDate = new DateTime(bdEntity.Year, bdEntity.Month, 1);
                bdEntity.EndDate = bdEntity.StartDate.Value.LastDayOfMonth();

            }
            else
            {
                response.StatusCode = 400;
                response.Message = "No se pudo modificar, por favor verifique que los datos sean correctos (ID).";
            }

            await _DB.SaveChangesAsync();

            return response;

        }

        public async Task<List<ActivityType>> ActivityTypeList()
        {

            return await _DB.ActivityTypes.AsNoTracking().Include(i=>i.Company).ToListAsync();

        }

        public async Task<BaseResponse<CreateActivityTypeResponse>> CreateActivityType(ActivityTypeRequest request)
        {
            var response = new BaseResponse<CreateActivityTypeResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new CreateActivityTypeResponse()
            };

            var item = _mapper.Map<ActivityType>(request);

            var company = await _DB.Companies.Where(i=> i.Id==request.CompanyId).FirstAsync();

            item.Company = company;

            var result = await _DB.ActivityTypes.AddAsync(item);

            if (result.IsKeySet)
            {
                response.Data.Id = result.Entity.Id;
            }
            else
            {
                response.StatusCode = 400;
                response.Message = "No se pudo crear, por favor verifique que los datos esten correctos";
            }

            await _DB.SaveChangesAsync();

            return response;

        }

        public async Task<BaseResponse<CreateActivityTypeResponse>> EditActivityType(EditActivityTypeRequest request)
        {
            var response = new BaseResponse<CreateActivityTypeResponse>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new CreateActivityTypeResponse()
            };

            var item = _mapper.Map<ActivityType>(request);

            var bdEntity = await _DB.ActivityTypes.Where(c => c.Id == item.Id).FirstOrDefaultAsync();

            if (bdEntity is not null)
            {
                var company = await _DB.Companies.Where(i => i.Id == request.CompanyId).FirstAsync();

                bdEntity.Code = item.Code;
                bdEntity.Description = item.Description;
                bdEntity.Company = company;

            }
            else
            {
                response.StatusCode = 400;
                response.Message = "No se pudo modificar, por favor verifique que los datos sean correctos (ID).";
            }

            await _DB.SaveChangesAsync();

            return response;

        }



    }
}
