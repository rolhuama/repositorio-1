using ColabManager360.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabManager360.Infrastructure.Data.Configurations
{
    internal class ActivityTypeInit : IEntityTypeConfiguration<ActivityType>
    {
        public void Configure(EntityTypeBuilder<ActivityType> builder)
        {

            var data = new List<ActivityType>
            {
                   new ActivityType { Code = "AT0001", Description = "Entrevista" },
                   new ActivityType { Code = "AT0002", Description = "Formación" },
                   new ActivityType { Code = "AT0003", Description = "Garantía" },
                   new ActivityType { Code = "AT0004", Description = "Gestión" },
                   new ActivityType { Code = "AT0005", Description = "Incidencias" },
                   new ActivityType { Code = "AT0006", Description = "Operaciones" },
                   new ActivityType { Code = "AT0007", Description = "Preventa" },
                   new ActivityType { Code = "AT0008", Description = "Proyecto" },
                   new ActivityType { Code = "AT0009", Description = "Servicio" },
                   new ActivityType { Code = "AT0010", Description = "Soporte TI" }


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
