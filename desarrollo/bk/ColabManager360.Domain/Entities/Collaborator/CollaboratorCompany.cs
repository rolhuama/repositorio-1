using ColabManager360.Domain.Common;
using ColabManager360.Domain.Entities.Client;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Collaborator
{
    public class CollaboratorCompany: BaseAuditableEntity
    {
        public int CollaboratorId { get; set; }
        public  int CompanyId { get; set; }

        [MaxLength(50)]
       
        
        public string? ClientPosition { get; set; }

        public virtual Collaborator Collaborator { get; set; }
        public virtual Company Company { get; set; }
    }
}
