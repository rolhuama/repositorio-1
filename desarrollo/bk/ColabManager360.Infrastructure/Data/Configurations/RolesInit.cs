using ColabManager360.Domain.Entities.Security.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabManager360.Infrastructure.Data.Configurations
{
    internal class RolesInit : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.HasData(
           new Roles { Id = "ADMIN", Name = "Administrador", NormalizedName = "Administrador" },
           new Roles { Id = "COLAB", Name = "Colaborador", NormalizedName = "Colaborador" },
           new Roles { Id = "SERVMAN", Name = "ServiceManager", NormalizedName = "ServiceManager" },
           new Roles { Id = "RRHH", Name = "RRHH", NormalizedName = "RRHH" }

            );
        }
    }
}
