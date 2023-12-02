using ColabManager360.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabManager360.Domain.Entities.Business
{
    public class WorkAreaTeam : BaseAuditableEntity
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        public virtual int WorkAreaId { get; set; }
        public virtual WorkArea WorkArea { get; set; }

        [MaxLength(50)]
        public string? Code { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
    }
}
