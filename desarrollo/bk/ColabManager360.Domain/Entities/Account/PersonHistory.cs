using ColabManager360.Domain.Common;
using ColabManager360.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Account
{
    public class PersonHistory : BaseAuditableEntity
    {
        [Key]
        [MaxLength(380)]
        public Guid Uid { get; set; }
        public virtual PersonInformation Person { get; set; }
        public virtual ActionType ActionType { get; set; }
        [MaxLength(250)]
        public string Action { get; set; }
        public string Comment { get; set; }
        public string Observation { get; set; }

    }
}
