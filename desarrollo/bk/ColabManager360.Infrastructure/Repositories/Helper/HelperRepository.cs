using ColabManager360.Domain.Entities.Activity.Responses;
using ColabManager360.Domain.Entities.Client;
using ColabManager360.Domain.Entities.Common;
using ColabManager360.Domain.Entities.Common.Requests;
using ColabManager360.Domain.Entities.Helper.Responses;
using ColabManager360.Domain.Interfaces.Helper;
using ColabManager360.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ColabManager360.Infrastructure.Repositories.Helper
{
    internal class HelperRepository : IHelperRepository
    {
        private readonly ApplicationDbContext _DBcontext;

        public HelperRepository(ApplicationDbContext dBcontext)
        {
            _DBcontext = dBcontext;
        }

        public async Task<AccountListResponse> AccountLists()
        {
            var response = new AccountListResponse();

            response.DocumentTypes = await _DBcontext.DocumentTypes.AsNoTracking().ToListAsync();
            response.Countries = await _DBcontext.Country.AsNoTracking().ToListAsync();
            response.Departments = await GetDepartments();

            return response;

        }

        public async Task<List<Ubigeo>> GetDepartments()
        {
            return await _DBcontext.Ubigeo.AsNoTracking().Where(u=> u.Province=="00" && u.District == "00").OrderBy(u => u.Name).ToListAsync();
        }

        public async Task<List<Ubigeo>> GetProvinces(string DepartmentCode)
        {
            return await _DBcontext.Ubigeo.AsNoTracking().Where(u => u.Department == DepartmentCode && u.District == "00" && u.Province!="00").OrderBy(u=> u.Name).ToListAsync();
        }
        public async Task<List<Ubigeo>> GetDistricts(string DepartmentCode,string ProvinceCode)
        {
            return await _DBcontext.Ubigeo.AsNoTracking().Where(u => u.Department == DepartmentCode && u.Province == ProvinceCode && u.District != "00").OrderBy(u => u.Name).ToListAsync();
        }
        public async Task<List<Country>> GetCountries()
        {
            return await _DBcontext.Country.AsNoTracking().OrderBy(i=>i.Name).ToListAsync();
        }

        public async Task<List<MasterDetailTable>> GetMasterList(MasterDetailTableRequest request)
        {
            return await _DBcontext.MasterDetailTable.AsNoTracking().Where(i=> i.TableName==request.TableName && i.TableCode == request.TableCode).OrderBy(i => i.Order).ToListAsync();
        }

        public async Task<List<ServiceType>> GetServiceTypes()
        {
            return await _DBcontext.ServiceTypes.AsNoTracking().OrderBy(i => i.Description).ToListAsync();
        }

        public async Task<List<CompanyService>> GetCompanyServicesList(int request)
        {
            return await _DBcontext.CompanyServices.Include(i=>i.Type).AsNoTracking().Where(i=> i.Company.Id== request).OrderBy(i => i.Description).ToListAsync();
        }

        public async Task<List<ActivityType>> GetCompanyActivityTypeList(int request)
        {
            return await _DBcontext.ActivityTypes.AsNoTracking().Where(i => i.Company.Id == request || i.Company.Id == null).OrderBy(i => i.Description).ToListAsync();
        }

        public async Task<List<PeriodWeekResponse>> GetPeriodWeekList()
        {
            var period = await _DBcontext.Periods
                                         .AsNoTracking()
                                         .OrderBy(i => i.Year)
                                         .ThenBy(i => i.Month)
                                         .FirstOrDefaultAsync(i => i.State == "A");

            var response = new List<PeriodWeekResponse>();

            if (period is not null) {
                // Definir el año y el mes
                int year = period.Year;
                int month = period.Month;

                // Crear un objeto Calendar para la cultura actual
                Calendar calendar = CultureInfo.CurrentCulture.Calendar;

                // Obtener el primer día del mes
                DateTime firstDayOfMonth = new DateTime(year, month, 1);

                // Obtener el último día del mes
                DateTime lastDayOfMonth = new DateTime(year, month, DateTime.DaysInMonth(year, month));


                // Encontrar el primer día de la semana que contiene el primer día del mes
                DateTime currentDay = firstDayOfMonth.AddDays(-(int)firstDayOfMonth.DayOfWeek);

                while (currentDay.DayOfWeek != DayOfWeek.Monday)
                {
                    currentDay = currentDay.AddDays(1);
                }

                // Iterar y mostrar las semanas
                while (currentDay <= lastDayOfMonth)
                {
                    DateTime startOfWeek = currentDay;
                    DateTime endOfWeek = currentDay.AddDays(6);

                    if (endOfWeek > lastDayOfMonth)
                    {
                        endOfWeek = lastDayOfMonth;
                    }

                    int week = calendar.GetWeekOfYear(startOfWeek, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

                    response.Add(new PeriodWeekResponse
                    {
                        Year = year,
                        Month = month,
                        Description = $"Semana {week}: {startOfWeek:ddd dd/MM/yyyy} - {endOfWeek:ddd dd/MM/yyyy}",
                        StartDate = startOfWeek,
                        EndDate = endOfWeek,
                        WeekNumber = week

                    });

                    //Console.WriteLine($"Semana: {startOfWeek:ddd dd/MM/yyyy} - {endOfWeek:ddd dd/MM/yyyy}");

                    // Mover al siguiente lunes
                    currentDay = currentDay.AddDays(7);
                }


                //// Obtener el número de la semana del primer y último día del mes
                //int firstWeek = calendar.GetWeekOfYear(firstDayOfMonth, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                //int lastWeek = calendar.GetWeekOfYear(lastDayOfMonth, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

                //// Mostrar las semanas del mes
                //for (int week = firstWeek; week <= lastWeek; week++)
                //{
                //    DateTime startOfWeek = firstDayOfMonth.AddDays((week - 1) * 7);
                //    DateTime endOfWeek = startOfWeek.AddDays(6);

                //    response.Add(new PeriodWeekResponse
                //    {
                //        Year = year,
                //        Month = month,
                //        Description= $"Semana {week}: {startOfWeek:ddd dd/MM/yyyy} - {endOfWeek:ddd dd/MM/yyyy}",
                //        StartDate = startOfWeek,
                //        EndDate = endOfWeek

                //    });


                //    //Console.WriteLine($"Semana {week}: {startOfWeek:ddd dd/MM/yyyy} - {endOfWeek:ddd dd/MM/yyyy}");
                //}
            }




            return response;
        }
    }
}
