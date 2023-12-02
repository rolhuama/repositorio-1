using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Client
{
    public class CompanyArea : BaseAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual Company Company { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }

    }
}
