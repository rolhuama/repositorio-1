using ColabManager360.Domain.Common.Responses;
using ColabManager360.Domain.Entities.Reports.Requests;
using ColabManager360.Domain.Entities.Reports.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabManager360.Aplication.Services.Reports
{
    public interface IReportService
    {
        Task<BaseResponse<List<DailyHoursInputResponse>>> DailyHoursInput(DailyHoursInputRequest request);
    }
}
