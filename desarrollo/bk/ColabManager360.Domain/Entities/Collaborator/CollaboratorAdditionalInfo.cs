using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;
using Attribute = ColabManager360.Domain.Entities.Common.Attribute;

namespace ColabManager360.Domain.Entities.Collaborator
{
    public class CollaboratorAdditionalInfo : BaseAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual Collaborator Collaborator { get; set; }
        public virtual Attribute Attribute { get; set; }
        [MaxLength(255)]
        public string Valor { get; set; }

    }
}
