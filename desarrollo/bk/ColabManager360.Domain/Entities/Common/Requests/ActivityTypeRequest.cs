using ColabManager360.Domain.Entities.Client;
using System.Text.Json.Serialization;

namespace ColabManager360.Domain.Entities.Common.Requests
{
    public class ActivityTypeRequest: ActivityType
    {
        [JsonIgnore]
        public override int Id { get; set; }

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
