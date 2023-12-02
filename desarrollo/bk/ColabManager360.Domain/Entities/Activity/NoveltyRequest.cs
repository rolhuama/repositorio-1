using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Activity
{
    public class NoveltyRequest : BaseAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual Novelty Novelty { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? TotalDays { get; set; }
        public char? ApprovedByDirectSupervisor { get; set; }
        public char? ApprovedByHR { get; set; }
        [MaxLength(20)]
        public string Status { get; set; }
        public string Observation { get; set; }
        public int? Type { get; set; }
    }
}
