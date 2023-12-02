using ColabManager360.Domain.Entities.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabManager360.Infrastructure.Data.Configurations
{
    internal class WorkAreaInit : IEntityTypeConfiguration<WorkArea>
    {
        public void Configure(EntityTypeBuilder<WorkArea> builder)
        {

            var data = new List<WorkArea>
            {
               new WorkArea { Name = "Digital" },
               new WorkArea { Name = "Consulting" },
               new WorkArea { Name = "Outsourcing" },
               new WorkArea { Name = "Security" },
               new WorkArea { Name = "Comercial" },
               new WorkArea { Name = "Finanzas" },
               new WorkArea { Name = "Gerencia" },
               new WorkArea { Name = "People" },
               new WorkArea { Name = "Training" }

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
