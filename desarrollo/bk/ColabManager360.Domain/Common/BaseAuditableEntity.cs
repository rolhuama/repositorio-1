using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColabManager360.Domain.Common
{
    public  abstract  class BaseAuditableEntity
    {
        [Column(TypeName = "datetime2 default getdate()")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual DateTime Created { get; set; }
        [MaxLength(50)]
        public virtual string? CreatedBy { get; set; }
        [Column(TypeName = "datetime2 default getdate()")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual DateTime? LastModified { get; set; }
        [MaxLength(50)]
        public virtual string? LastModifiedBy { get; set; }
    }
}
