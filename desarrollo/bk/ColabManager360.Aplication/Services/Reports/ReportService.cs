using ColabManager360.Domain.Common.Responses;
using ColabManager360.Domain.Entities.Reports.Requests;
using ColabManager360.Domain.Entities.Reports.Responses;
using ColabManager360.Domain.Interfaces.Reports;

namespace ColabManager360.Aplication.Services.Reports
{
    internal class ReportService: IReportService
    {
        private readonly IReportRepository _ReportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _ReportRepository = reportRepository;
        }

        public async Task<BaseResponse<List<DailyHoursInputResponse>>> DailyHoursInput(DailyHoursInputRequest request)
        {
            return await _ReportRepository.DailyHoursInput(request);
        }
    }
}
