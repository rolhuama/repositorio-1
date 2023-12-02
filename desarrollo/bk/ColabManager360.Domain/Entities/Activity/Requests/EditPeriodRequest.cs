using ColabManager360.Domain.Entities.Common;
using System.Text.Json.Serialization;

namespace ColabManager360.Domain.Entities.Activity.Requests
{
    public class EditPeriodRequest:Period
    {
        [JsonIgnore]
        public override DateTime? StartDate { get; set; }
        [JsonIgnore]
        public override DateTime? EndDate { get; set; }
        [JsonIgnore]
        public override MasterDetailTable? StateMasterTable { get; set; }

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
