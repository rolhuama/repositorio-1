using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ColabManager360.Infrastructure.Data
{
    internal class DbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var OptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            //Solo vive en tiempo de Diseño
            OptionsBuilder.UseSqlServer("Server=localhost;Database=ColabManager360;User Id=admin;Password=$AdminSQL2023.;TrustServerCertificate=true;");

            return new ApplicationDbContext(OptionsBuilder.Options);
        }
    }
}
