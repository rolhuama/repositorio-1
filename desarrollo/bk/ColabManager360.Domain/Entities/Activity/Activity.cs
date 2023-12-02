using ColabManager360.Domain.Common;
using ColabManager360.Domain.Entities.Client;
using ColabManager360.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColabManager360.Domain.Entities.Activity
{
    public class Activity : BaseAuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(380)]
        public virtual string Id { get; set; }
        public virtual Collaborator.Collaborator Collaborator { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? DurationHours { get; set; }
        public int? DurationDays { get; set; }
        public int? DurationMonths { get; set; }
        public string Description { get; set; }
        public virtual ActivityType ActivityType { get; set; }
        public virtual CompanyService CompanyService { get; set; }
        [MaxLength(20)]
        public virtual string Status { get; set; }
        public bool NotifiesHR { get; set; }
        public bool CoordinatesWithClient { get; set; }
        public virtual Company Company { get; set; }
        public string? Observation { get; set; }
        public string? TicketCode { get; set; }
        public int Order { get; set; } = 1;
        public int? Week { get; set; }
        public Period? Period { get; set; }
        public virtual ICollection<ActivityDetail> Detail { get; set; }

    }
}
