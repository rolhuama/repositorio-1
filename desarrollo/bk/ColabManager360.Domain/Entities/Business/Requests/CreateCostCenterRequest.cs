using System.Text.Json.Serialization;

namespace ColabManager360.Domain.Entities.Business.Requests
{
    public  class CreateCostCenterRequest: CostCenter
    {
        [JsonIgnore]
        public override int Id { get; set; }



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
