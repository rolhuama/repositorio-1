using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColabManager360.Domain.Entities.Activity
{
    public class ActivityDetail:BaseAuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(380)]
        public virtual string Id { get; set; }
        public virtual Activity Activity { get; set; }
        public int Week { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string DayName { get; set; }
        public int Hours { get; set; }
        public DateTime? Date { get; set; }


    }
}
