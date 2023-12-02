using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Common
{
    public class ActionType : BaseAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
