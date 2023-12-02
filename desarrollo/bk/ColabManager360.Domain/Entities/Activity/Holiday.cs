using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Activity
{
    public class Holiday:BaseAuditableEntity
    {
        [Key]
        public virtual int Id { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set;}
        public int days { get; set; }

    }
}
