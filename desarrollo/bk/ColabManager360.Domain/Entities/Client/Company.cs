using ColabManager360.Domain.Common;
using ColabManager360.Domain.Entities.Business;
using ColabManager360.Domain.Entities.Collaborator;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Client
{
    public class Company : BaseAuditableEntity
    {
        [Key]
        public virtual int Id { get; set; }
        [MaxLength(350)]
        public string LegalName { get; set; }
        [MaxLength(350)]
        public string CommercialName { get; set; }
        public string FiscalAddress { get; set; }
        [MaxLength(50)]
        public string TaxIdentificationNumber { get; set; }
        [MaxLength(150)]
        public string? EconomicSector { get; set; }
        [MaxLength(10)]
        public string Country { get; set; }
        public virtual CostCenter? CostCenter { get; set; }
        public bool IsInterCompany { get; set; }=false;
        public bool IsActive { get; set; }

        public virtual ICollection<CompanyArea> Areas { get; set; }
        public virtual ICollection<CompanyService> Services { get; set; }
        public virtual ICollection<ContactService> Contacts { get; set; }
        public virtual ICollection<CollaboratorCompany> CollaboratorCompanies { get; set; }
    }
}
