using ColabManager360.Domain.Common;
using ColabManager360.Domain.Entities.Business;
using ColabManager360.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColabManager360.Domain.Entities.Account
{
    public class PersonInformation : BaseAuditableEntity
    {
        [Key]
        [MaxLength(380)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Uid { get; set; }
        [MaxLength(20)]
        public string? EntelgyCode { get; set; }
        [MaxLength(150)]
        public string FirstName1 { get; set; }
        [MaxLength(150)]
        public string FirstName2 { get; set; }
        [MaxLength(150)]
        public string LastName1 { get; set; }
        [MaxLength(150)]
        public string LastName2 { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        [MaxLength(50)]
        public string DocumentNumber { get; set; }
        public DateTime Birthday { get; set; }
        [MaxLength(255)]
        public string PersonalEmail { get; set; }
        [MaxLength(255)]
        public string WorkEmail { get; set; }
        [MaxLength(20)]
        public string PersonalCellPhone { get; set; }
        [MaxLength(20)]
        public string? WorkCellPhone { get; set; }
        public DateTime EntelgyStartDate { get; set; }
        public DateTime? EntelgyEndDate { get; set; }
        public int IsActive { get; set; }
        [MaxLength(50)]
        public string? Position { get; set; }
        //[MaxLength(50)]
        //public string? ClientPosition { get; set; }
        [MaxLength(1)]
        public string Gender { get; set; }
        public virtual EntryType? EntryType { get; set; }
        public virtual BusinessUnit? BusinessUnit { get; set; }

        [MaxLength(100)]
        public string? EntelgyContractProfile { get; set; }
        [MaxLength(100)]
        public string? EntelgyContractCategory { get; set; }

        public decimal? YearsOfExperience { get; set; }

        public string Address { get; set; }
        public string ReferenceAddress { get; set; }
        [MaxLength(10)]
        public string District { get; set; }
        [MaxLength(10)]
        public string Province { get; set; }
        [MaxLength(10)]
        public string Department { get; set; }
        [MaxLength(10)]
        public string Country { get; set; }
        [MaxLength(20)]
        public string Nationality { get; set; }
        public bool HasChildren { get; set; }


        public ICollection<PersonLanguage> PersonLanguages { get; set; }
        public ICollection<PersonCertification> PersonCertifications { get; set; }
        public ICollection<PersonDocument> PersonDocuments { get; set; }
        public ICollection<PersonHistory> PersonHistories { get; set; }

    }
}
