using ColabManager360.Domain.Entities.Client;
using ColabManager360.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ColabManager360.Domain.Entities.Activity.Requests
{
    public class ActivityRequest:Activity
    {
        [JsonIgnore]
        public override string? Id { get; set; }

        public override string? Status { get; set; }

        public  DailyActivityTypeRequest? ActivityType { get; set; }
        public  DailyCompanyServiceRequest? CompanyService { get; set; }

        public ICollection<ActivityDetailRequest> Detail { get; set; }



        [JsonIgnore]
        public override Collaborator.Collaborator? Collaborator { get; set; }

        //[JsonIgnore]
        //public override ActivityType? ActivityType { get; set; }

        //[JsonIgnore]
        //public override CompanyService? CompanyService { get; set; }

        [JsonIgnore]
        public override Company? Company { get; set; }

        //[JsonIgnore]
        //public override ICollection<ActivityDetail> Detail { get; set; }


        [JsonIgnore]
        public override DateTime Created { get; set; }
        [JsonIgnore]
        public override string? CreatedBy { get; set; }
        [JsonIgnore]
        public override DateTime? LastModified { get; set; }
        [JsonIgnore]
        public override string? LastModifiedBy { get; set; }

    }
}
