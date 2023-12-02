using ColabManager360.Domain.Entities.Security.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabManager360.Infrastructure.Data.Configurations
{
    internal class UserRoleInit : IEntityTypeConfiguration<UserRoles>
    {
        public void Configure(EntityTypeBuilder<UserRoles> builder)
        {          

            var UserRole = new UserRoles { UserId="100", RoleId= "ADMIN" };

            builder.HasData(UserRole);
        }
    }
}
