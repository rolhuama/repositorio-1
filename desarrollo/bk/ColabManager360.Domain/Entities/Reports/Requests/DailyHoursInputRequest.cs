

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabManager360.Domain.Entities.Reports.Requests
{
    public class DailyHoursInputRequest
    {
        public int CompanyId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
