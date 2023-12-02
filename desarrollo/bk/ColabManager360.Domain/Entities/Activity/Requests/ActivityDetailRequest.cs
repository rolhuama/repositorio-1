using ColabManager360.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ColabManager360.Domain.Entities.Activity.Requests
{
    public  class ActivityDetailRequest:ActivityDetail
    {
        [JsonIgnore]
        public override string? Id { get; set; }

        [JsonIgnore]
        public override  Activity? Activity { get; set; }


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
