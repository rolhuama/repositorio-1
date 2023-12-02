using ColabManager360.Domain.Common;
using ColabManager360.Domain.Entities.Client;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Common
{
    public class ActivityType : BaseAuditableEntity
    {
        [Key]
 
        public virtual int Id { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public virtual Company? Company { get; set; }

    }
}
