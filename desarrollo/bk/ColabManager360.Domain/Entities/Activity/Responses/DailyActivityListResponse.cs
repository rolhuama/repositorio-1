﻿using ColabManager360.Domain.Entities.Activity.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabManager360.Domain.Entities.Activity.Responses
{
    public class DailyActivityListResponse
    {
        public ICollection<ActivityRequest> Activities { get; set; }
    }
}
