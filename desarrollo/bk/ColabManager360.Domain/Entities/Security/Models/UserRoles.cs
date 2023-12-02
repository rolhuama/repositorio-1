using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColabManager360.Domain.Entities.Security.Models
{
    [Table("UserRoles")]
    public class UserRoles : IdentityUserRole<string>
    {
        public virtual Users User { get; set; }
        public virtual Roles Role { get; set; }
    }
}
