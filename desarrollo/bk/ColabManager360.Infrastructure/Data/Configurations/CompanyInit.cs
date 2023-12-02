using ColabManager360.Domain.Entities.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabManager360.Infrastructure.Data.Configurations
{
    internal class CompanyInit : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {  
            var data = new List<Company>
            {
                new Company {TaxIdentificationNumber ="20100115663", LegalName="PANDERO S.A.", CommercialName="Pandero",FiscalAddress="Av. Dos de Mayo Nro. 382", Country="PE", IsActive=true }

            };

            int i = 1;
            foreach (var item in data)
            {
                item.Id = i++;
            }

            builder.HasData(data);
        }
    }
}
