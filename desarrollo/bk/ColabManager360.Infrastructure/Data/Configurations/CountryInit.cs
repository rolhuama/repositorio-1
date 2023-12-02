using ColabManager360.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabManager360.Infrastructure.Data.Configurations
{
    internal class CountryInit : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
           new Country { Id = "PE", Name = "Perú"},
           new Country { Id = "AR", Name = "Argentina" },
           new Country { Id = "BR", Name = "Brasil" },
           new Country { Id = "CL", Name = "Chile" },
           new Country { Id = "CO", Name = "Colombia" },
           new Country { Id = "MX", Name = "México" },
           new Country { Id = "US", Name = "USA" }
            );
        }
    }
}
