using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Common
{
    public class Country : BaseAuditableEntity
    {
        [Key]
        [MaxLength(10)]
        public string Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }


    }
}
