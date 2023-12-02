using ColabManager360.Domain.Entities.Business.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ColabManager360.Domain.Entities.Business.Responses
{
    public class WorkInfoResponse:WorkInfoRequest
    {
        [JsonIgnore]
        public override string UserId { get; set; }
    }
}
