using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Activity
{
    public class Novelty : BaseAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual Collaborator.Collaborator Collaborator { get; set; }
        public int? InitialDays { get; set; }
        public int? AccumulatedDays { get; set; }
        public int? ConsumedDays { get; set; }
        public int? AvailableDays { get; set; }

        public ICollection<NoveltyRequest> NoveltyRequests { get; set; }

    }
}
