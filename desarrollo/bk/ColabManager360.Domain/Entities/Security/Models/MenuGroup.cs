using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Security.Models
{
    public class MenuGroup : BaseAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        public int? Order { get; set; }
        [MaxLength(50)]
        public string? Icon { get; set; }
    }
}
