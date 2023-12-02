using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Common
{
    public class Ubigeo : BaseAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Department { get; set; }
        [MaxLength(20)]
        public string Province { get; set; }
        [MaxLength(20)]
        public string District { get; set; }
        [MaxLength(20)]
        public string? Region { get; set; }
        [MaxLength(20)]
        public string? Zone { get; set; }
        [MaxLength(20)]
        public string? PostalCode { get; set; }
        [MaxLength(10)]
        public string Country { get; set; }
    }
}
