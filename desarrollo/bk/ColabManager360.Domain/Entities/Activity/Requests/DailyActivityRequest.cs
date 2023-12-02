using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabManager360.Domain.Entities.Activity.Requests
{
    public class DailyActivityRequest
    {
        public string UserId { get; set; }
        public int CompanyId { get; set; }
        public DailyActivityPeriodRequest Period { get; set; }

        public int WeekNumber { get; set; }

        public ICollection<ActivityRequest> Activities { get; set; }

    }


}
