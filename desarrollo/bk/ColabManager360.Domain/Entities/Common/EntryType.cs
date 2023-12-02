using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Common
{
    public class EntryType : BaseAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }

    }
}
