using ColabManager360.Domain.Entities.Security.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabManager360.Infrastructure.Data.Configurations
{
    internal class MenuGroupInit : IEntityTypeConfiguration<MenuGroup>
    {
        public void Configure(EntityTypeBuilder<MenuGroup> builder)
        {

            var data = new List<MenuGroup>
            {
                new MenuGroup { Id = 1, Name = "Dashboard", Order =1 , Icon="bi bi-grid" },
                new MenuGroup { Id = 2, Name = "Actividades", Order =2, Icon="bi bi-journal-text" },
                new MenuGroup { Id = 3, Name = "Novedades", Order =3, Icon="bi bi-journal-text"  },
                new MenuGroup { Id = 4, Name = "Reportes", Order =4, Icon="bi bi-bar-chart"  },
                new MenuGroup { Id = 5, Name = "People", Order =5, Icon="bi bi-people"  },
                new MenuGroup { Id = 6, Name = "Configuraciones", Order =6, Icon="bi bi-gear"  },
                new MenuGroup { Id = 7, Name = "Administración", Order =7, Icon="bi bi-building-fill-gear"  },
                new MenuGroup { Id = 8, Name = "Cuenta", Order =8, Icon="bi bi-person"  }
            };

            builder.HasData(data);
        }
    }
}
