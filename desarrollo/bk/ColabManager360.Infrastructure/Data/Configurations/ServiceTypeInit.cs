using ColabManager360.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabManager360.Infrastructure.Data.Configurations
{
    internal class ServiceTypeInit : IEntityTypeConfiguration<ServiceType>
    {
        public void Configure(EntityTypeBuilder<ServiceType> builder)
        {

            var data = new List<ServiceType>
            {
                new ServiceType { Description = "Proyecto" , IsActive=true},
                new ServiceType { Description = "Servicio", IsActive=true}              

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
