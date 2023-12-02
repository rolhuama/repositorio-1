using ColabManager360.Domain.Common;
using ColabManager360.Domain.Entities.Account;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.ServiceManager
{
    public class ServiceManager : BaseAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual PersonInformation Person { get; set; }

        //public ICollection<Collaborator.Collaborator> Collaborators { get; set; }
        public ICollection<ServiceManagerCollaborator> ServiceManagerCollaborators { get; set; }

    }
}
