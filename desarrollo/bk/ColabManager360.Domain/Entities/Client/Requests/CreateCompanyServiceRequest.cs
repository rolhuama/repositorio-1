using ColabManager360.Domain.Entities.Business;
using ColabManager360.Domain.Entities.Common;
using System.Text.Json.Serialization;

namespace ColabManager360.Domain.Entities.Client.Requests
{
    public class CreateCompanyServiceRequest:CompanyService
    {
        [JsonIgnore]
        public override int Id { get; set; }


        public  int CompanyId { get; set; }
        public int TypeId { get; set; }
        public string CostCenterCode { get; set; }


        [JsonIgnore]
        public override Company? Company { get; set; }
        [JsonIgnore]
        public virtual ServiceType? Type { get; set; }
        [JsonIgnore]
        public virtual CostCenter? CostCenter { get; set; }

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
