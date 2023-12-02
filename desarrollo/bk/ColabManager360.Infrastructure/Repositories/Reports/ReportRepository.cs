using AutoMapper;
using ColabManager360.Domain.Common.Responses;
using ColabManager360.Domain.Entities.Reports.Requests;
using ColabManager360.Domain.Entities.Reports.Responses;
using ColabManager360.Domain.Interfaces.Reports;
using ColabManager360.Infrastructure.Data;
using ColabManager360.Infrastructure.Data.Extensions.Context;
using ColabManager360.Infrastructure.Repositories.Reports.Resources;


namespace ColabManager360.Infrastructure.Repositories.Reports
{
    internal class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _DB;
        private readonly IMapper _mapper;       

        public ReportRepository(ApplicationDbContext dB, IMapper mapper)
        {
            _DB = dB;
            _mapper = mapper;
        }


        public async Task<BaseResponse<List<DailyHoursInputResponse>>> DailyHoursInput(DailyHoursInputRequest request)
        {
            var response = new BaseResponse<List<DailyHoursInputResponse>>
            {
                Success = true,
                StatusCode = 200,
                Message = "OK",
                Data = new List<DailyHoursInputResponse>()
            };

            try
            {
                var sqlQuery = string.Format(ReportQuery.DailyHoursInput, request.CompanyId, request.Year, request.Month);

                var report = _DB.ExecuteSqlQuery<DailyHoursInputResponse>(sqlQuery);

                response.Data = report;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.StatusCode = 500;
                response.Message =ex.Message;
            }


            return response;


        }

    }
}
