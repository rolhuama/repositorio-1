using ColabManager360.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Client
{
    public class ContactService
    {
        [Key]
        public int Id { get; set; }
        public virtual ServiceType ServiceType { get; set; }
        public virtual Company Company { get; set; }
        [MaxLength(350)]
        public string Description { get; set; }
        [MaxLength(150)]
        public string FirstName1 { get; set; }
        [MaxLength(150)]
        public string FirstName2 { get; set; }
        [MaxLength(150)]
        public string LastName1 { get; set; }
        [MaxLength(150)]
        public string LastName2 { get; set; }
        [MaxLength(255)]
        public string EmailContact { get; set; }
        [MaxLength(20)]
        public string CellPhoneContact { get; set; }
        [MaxLength(50)]
        public string Position { get; set; }
        [MaxLength(100)]
        public string Type { get; set; }

    }
}
