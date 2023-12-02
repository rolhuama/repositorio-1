using ColabManager360.Domain.Entities.Security.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabManager360.Infrastructure.Data.Configurations
{
    internal class MenuInit : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            var icon = "bi bi-circle";
            var data = new List<Menu>
            {
                new Menu {Name = "Dashboard", Url = "/dashboard", Icon = icon, GroupId=1 },
                new Menu {Name = "Registro Diario", Url = "/activities/daily", Icon = icon,  GroupId=2  },
                //new Menu {Name = "Registro Horas Extras", Url = "/activities/daily", Icon = icon,  GroupId=2  },
                new Menu {Name = "Solicitar Vacaciones", Url = "/novelty/vacation-request", Icon = icon,  GroupId=3 },
                //new Menu {Name = "Seguimiento", Url = "/reports/staff-monitoring", Icon = icon,  GroupId=4 },
                new Menu {Name = "Inputación de Horas", Url = "/reports/collaborator/daily-hours-input", Icon = icon,  GroupId=4 },
                new Menu {Name = "Feriados", Url = "/people/holidays-config", Icon = icon,  GroupId=5 },
                new Menu {Name = "Periodos", Url = "/people/periods-config", Icon = icon,  GroupId=5 },
                new Menu {Name = "Tipos Actividad Diaria", Url = "/people/activity-type-config", Icon = icon,  GroupId=5 },
                new Menu {Name = "Gestión Colaboradores", Url = "/config/collaborator-managment", Icon = icon, GroupId = 6  },
                new Menu {Name = "Gestión Clientes", Url = "/config/company-config", Icon = icon, GroupId = 6  },
                new Menu {Name = "Usuarios", Url = "/admin/users", Icon = icon, GroupId = 7 },
                new Menu {Name = "Roles", Url = "/admin/roles", Icon = icon, GroupId = 7 },
                new Menu {Name = "Clientes", Url = "/admin/companies", Icon = icon, GroupId = 7 },
                new Menu {Name = "CECO", Url = "/admin/ceco", Icon = icon, GroupId = 7 },
                new Menu {Name = "Áreas de Trabajo", Url = "/admin/work-areas", Icon = icon, GroupId = 7 }

            };

            int i = 1;
            foreach (var item in data) {
                item.Id = i++;
            }

            builder.HasData(data);
        }
    }
}
