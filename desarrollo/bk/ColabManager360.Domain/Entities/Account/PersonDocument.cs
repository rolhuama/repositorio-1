using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Account
{
    public class PersonDocument : BaseAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual PersonInformation Person { get; set; }
        [MaxLength(250)]
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public bool? Sent { get; set; }
        public bool? Received { get; set; }
        public bool? Attendance { get; set; }

    }
}
