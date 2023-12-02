using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Business
{
    public class CostCenter: BaseAuditableEntity
    {
        [Key]
        public virtual int Id { get; set; }
        [MaxLength(50)]
        public string? Code { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
    }
}
