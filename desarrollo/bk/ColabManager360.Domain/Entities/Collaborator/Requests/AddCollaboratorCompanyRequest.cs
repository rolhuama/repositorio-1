using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabManager360.Domain.Entities.Collaborator.Requests
{
    public  class AddCollaboratorCompanyRequest
    {
        public int CollaboratorId { get; set; }
        public int CompanyId { get; set; }
    }
}
