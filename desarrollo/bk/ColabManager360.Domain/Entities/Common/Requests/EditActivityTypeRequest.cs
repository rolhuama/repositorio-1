using ColabManager360.Domain.Entities.Client;
using System.Text.Json.Serialization;

namespace ColabManager360.Domain.Entities.Common.Requests
{
    public class EditActivityTypeRequest: ActivityType
    {
        public int CompanyId { get; set; }

        [JsonIgnore]
        public override Company? Company { get; set; }

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
