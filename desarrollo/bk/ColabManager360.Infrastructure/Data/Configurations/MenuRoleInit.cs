using ColabManager360.Domain.Entities.Security.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabManager360.Infrastructure.Data.Configurations
{
    internal class MenuRoleInit : IEntityTypeConfiguration<MenuRoles>
    {
        public void Configure(EntityTypeBuilder<MenuRoles> builder)
        {
       
            var data = new List<MenuRoles>
            {
                new MenuRoles {MenuId = 1, RoleId= "COLAB" },
                new MenuRoles {MenuId = 2, RoleId= "COLAB" },
                new MenuRoles {MenuId = 3, RoleId= "COLAB" },
                //new MenuRoles {MenuId = 4, RoleId= "COLAB" }

            };

            builder.HasData(data);
        }
    }
}
