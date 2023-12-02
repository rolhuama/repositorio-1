using ColabManager360.Domain.Common;
using ColabManager360.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Activity
{
    public class Period : BaseAuditableEntity
    {

        [Key]
        public virtual string Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;
        //[MaxLength(25)]
        public virtual MasterDetailTable StateMasterTable { get; set; }
        public string State { get; set; }
        public int? MaximumDays { get; set; }
        public int? MaximumHours { get; set; }

        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }

    }
}
