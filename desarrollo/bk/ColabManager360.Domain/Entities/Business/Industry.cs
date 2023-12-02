using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Business
{
    public class Industry : BaseAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Code { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
