using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Client
{
    public class CompanyAreaCollaborator : BaseAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual CompanyArea CompanyArea { get; set; }
        public virtual Collaborator.Collaborator Collaborator { get; set; }
        public bool? IsActive { get; set; }

    }
}
