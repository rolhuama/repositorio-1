using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColabManager360.Domain.Entities.Security.Models
{
    [Table("Roles")]
    public class Roles : IdentityRole
    {
        [MaxLength(10)]  
        public override string Id { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
