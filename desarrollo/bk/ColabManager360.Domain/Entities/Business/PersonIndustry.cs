using ColabManager360.Domain.Common;
using ColabManager360.Domain.Entities.Account;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Business
{
    public class PersonIndustry : BaseAuditableEntity
    {
        
        public int IndustryId { get; set; }
        [MaxLength(380)]
        public Guid PersonId { get; set; }

        public virtual Industry Industry { get; set; }
       
        public virtual PersonInformation Person { get; set; }

    }
}
