using ColabManager360.Domain.Entities.Security.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabManager360.Infrastructure.Data.Configurations
{
    internal class UserInit : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            var passwordHasher = new PasswordHasher<Users>();

            var User = new Users 
            { 
                Id = "100", 
                UserName = "admin@admin", 
                NormalizedUserName = "ADMIN@ADMIN",
                Email= "admin@admin",
                NormalizedEmail= "ADMIN@ADMIN"
            };

            var PasswordHash = passwordHasher.HashPassword(User, "admin@admin.");

            User.PasswordHash = PasswordHash;

            builder.HasData(User);
        }
    }
}
