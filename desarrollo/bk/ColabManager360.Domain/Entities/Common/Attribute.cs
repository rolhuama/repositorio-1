using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Common
{
    public class Attribute : BaseAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        [MaxLength(20)]
        public string DataType { get; set; }
    }
}
