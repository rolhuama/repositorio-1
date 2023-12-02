using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabManager360.Domain.Entities.Collaborator.Responses
{
    public  class CollaboratorCompanyListResponse
    {
        public int CollaboratorId { get; set; }
        public int CompanyId { get; set; }

        public string LegalName { get; set; }
   
        public string CommercialName { get; set; }

        public string? ClientPosition { get; set; }
    }
}
