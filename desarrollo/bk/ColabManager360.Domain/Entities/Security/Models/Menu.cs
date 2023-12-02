using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColabManager360.Domain.Entities.Security.Models
{
    public class Menu :BaseAuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Url { get; set; }
        [MaxLength(50)]
        public string Icon { get; set; }
        public int Order { get; set; }
        public int GroupId { get; set; }
        public virtual MenuGroup  Group { get; set; }
    }
}
