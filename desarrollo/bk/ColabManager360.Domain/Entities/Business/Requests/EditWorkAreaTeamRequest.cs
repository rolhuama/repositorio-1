using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ColabManager360.Domain.Entities.Business.Requests
{
    public class EditWorkAreaTeamRequest:WorkAreaTeam
    {



        [JsonIgnore]
        public override WorkArea? WorkArea { get; set; }

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
