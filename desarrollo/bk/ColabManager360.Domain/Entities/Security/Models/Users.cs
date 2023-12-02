using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ColabManager360.Domain.Entities.Account;
using Microsoft.AspNetCore.Identity;

namespace ColabManager360.Domain.Entities.Security.Models
{
    [Table("Users")]
    public class Users : IdentityUser
    {
        [MaxLength(380)]
        public override string Id { get; set; }

        public PersonInformation? Person { get; set; }
        public string? Picture { get; set; }

        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
