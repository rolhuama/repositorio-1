using ColabManager360.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace ColabManager360.Infrastructure.Data.Configurations
{
    internal class UbigeoInit : IEntityTypeConfiguration<Ubigeo>
    {
        public void Configure(EntityTypeBuilder<Ubigeo> builder)
        {
            // Leer el archivo JSON       
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var projectFolderName = "ColabManager360.Infrastructure";
            var projectFolderPath = Directory.GetParent(projectFolderName).FullName.Replace("ColabManager360.Api", projectFolderName);

            var jsonFilePath = Path.Combine(projectFolderPath, @"Data\Resources\"); ; // Cambia esta ruta a la ubicación real del archivo
            var jsonFileName = "UBIGEO.json";
            var jsonContent = File.ReadAllText(jsonFilePath + jsonFileName);

            // Convertir el contenido JSON en objetos C#
            var dataObject = JsonConvert.DeserializeObject<UbigeoFile>(jsonContent);

            if (dataObject != null)
            {
                var dataList = dataObject.UBIGEO;

                // Agregar los objetos al builder
                int index = 1;

                var ubigeoList = (from item in dataList
                                  select new Ubigeo
                                  {
                                      Id = index++,
                                      Name = item.NOMBRE_UBIGEO,
                                      Department = item.COD_DPTO,
                                      Province = item.COD_PROVINCIA,
                                      District = item.COD_DISTRITO,
                                      Country = "PE"
                                  }).ToList();

                builder.HasData(ubigeoList);
            }


        }

        private sealed class UbigeoFile
        {
            public ICollection<UbigeoConfig> UBIGEO { get; set; }

        }

        private sealed class UbigeoConfig
        {
            public int NRO { get; set; }
            public string COD_DPTO { get; set; }
            public string COD_PROVINCIA { get; set; }
            public string COD_DISTRITO { get; set; }
            public string NOMBRE_UBIGEO { get; set; }
        }



    }
}
