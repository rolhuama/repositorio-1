using ColabManager360.Domain.Entities.Collaborator;
using System.Text.Json.Serialization;

namespace ColabManager360.Domain.Entities.Client.Requests
{
    public class CompanyRequest: Company
    {
        [JsonIgnore]
        public override int Id { get; set; }

        public  string? costCenterCode { get; set; }

        [JsonIgnore]
        public override ICollection<CompanyArea>? Areas { get; set; }
        [JsonIgnore]
        public override ICollection<CompanyService>? Services { get; set; }
        [JsonIgnore]
        public override ICollection<ContactService>? Contacts { get; set; }
        [JsonIgnore]
        public override ICollection<CollaboratorCompany>? CollaboratorCompanies { get; set; }

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
