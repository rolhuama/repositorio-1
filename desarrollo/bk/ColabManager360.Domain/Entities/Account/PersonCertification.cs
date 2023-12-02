using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Account
{
    public class PersonCertification: BaseAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual PersonInformation Person { get; set; }
        [MaxLength(255)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(255)]
        public decimal? Grade { get; set; }
        [MaxLength(20)]
        public string Status { get; set; }
        [MaxLength(250)]
        public string StudyCenter { get; set; }

    }
}
