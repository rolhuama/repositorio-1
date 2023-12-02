using ColabManager360.Domain.Entities.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ColabManager360.Domain.Entities.Collaborator.Requests
{
    public class EditCollaboratorCompanyRequest: CollaboratorCompany
    {
        [JsonIgnore]
        public override Collaborator? Collaborator { get; set; }
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
