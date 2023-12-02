using ColabManager360.Domain.Common;
using ColabManager360.Domain.Entities.Client;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Collaborator
{
    public class CollaboratorContact : BaseAuditableEntity
    {
      
        public int CollaboratorId { get; set; }
  
        public int ContactServiceId { get; set; }

        public virtual Collaborator Collaborator { get; set; }

        public virtual ContactService ContactService { get; set; }
        [MaxLength(255)]
        public string Realtion { get; set; }

    }
}
