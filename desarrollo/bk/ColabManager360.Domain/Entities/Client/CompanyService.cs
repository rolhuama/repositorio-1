using ColabManager360.Domain.Common;
using ColabManager360.Domain.Entities.Business;
using ColabManager360.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Client
{
    public class CompanyService: BaseAuditableEntity
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual Company Company { get; set; }
        [MaxLength(50)]
        public string? Code { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }

        public virtual ServiceType Type { get; set; }
        public virtual CostCenter? CostCenter { get; set; }
    }
}
