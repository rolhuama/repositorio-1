using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabManager360.Domain.Entities.Activity.Responses
{
    public class PeriodWeekResponse
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int WeekNumber { get; set; }
        public  DateTime? StartDate { get; set; }
        public  DateTime? EndDate { get; set; }
        public string Description { get; set; }

    }


}
