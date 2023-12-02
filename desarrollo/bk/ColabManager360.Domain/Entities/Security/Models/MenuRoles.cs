using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Security.Models
{
    public class MenuRoles
    {
        public int MenuId { get; set; }
        [MaxLength(10)]
        public string RoleId { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual Roles Role { get; set; }

    }
}
