﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabManager360.Domain.Entities.Activity.Requests
{
    public class DailyActivityListRequest
    {
        public string UserId { get; set; }
        public int CompanyId { get; set; }
        public int Week { get; set; }

    }
}