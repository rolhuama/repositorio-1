using ColabManager360.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Account
{
    public class PersonLanguage : BaseAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual PersonInformation Person { get; set; }
        [MaxLength(50)]
        public string Idioma { get; set; }
        [MaxLength(20)]
        public string Nivel { get; set; }

    }
}
