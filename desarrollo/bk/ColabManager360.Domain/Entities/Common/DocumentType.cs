using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Common
{
    public class DocumentType : BaseAuditableEntity
    {
        [Key]
        [MaxLength(10)]
        public string Id { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [MaxLength(10)]
        public string? Country { get; set; }
       
    }
}
