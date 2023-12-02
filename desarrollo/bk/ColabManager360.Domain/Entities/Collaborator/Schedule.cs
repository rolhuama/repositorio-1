using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Collaborator
{
    public class Schedule : BaseAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        [MaxLength(255)]
        public string Type { get; set; }
        [MaxLength(255)]
        public string From { get; set; }
        [MaxLength(255)]
        public string To { get; set; }

        public int CollaboratorId { get; set; }
        public virtual Collaborator Collaborator { get; set; }
    }
}
