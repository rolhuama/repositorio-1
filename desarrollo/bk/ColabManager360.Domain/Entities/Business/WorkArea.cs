using ColabManager360.Domain.Common;
using ColabManager360.Domain.Entities.Activity.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabManager360.Domain.Entities.Business
{
    public class WorkArea : BaseAuditableEntity
    {
        [Key]
        public virtual int Id { get; set; }
        [MaxLength(50)]
        public string? Code { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }

        public virtual ICollection<WorkAreaTeam> Teams { get; set; }


    }
}
