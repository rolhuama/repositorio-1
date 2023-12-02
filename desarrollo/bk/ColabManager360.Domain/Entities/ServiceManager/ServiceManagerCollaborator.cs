using ColabManager360.Domain.Common;
using ColabManager360.Domain.Entities.Client;

namespace ColabManager360.Domain.Entities.ServiceManager
{
    public class ServiceManagerCollaborator : BaseAuditableEntity
    {
        public int ServiceManagerId { get; set; }
        public int CollaboratorId { get; set; }
        public virtual ServiceManager ServiceManager { get; set; }
        public virtual Collaborator.Collaborator Collaborator { get; set; }
        public virtual Company Company { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }

    }
}
