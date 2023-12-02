using ColabManager360.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabManager360.Infrastructure.Data.Configurations
{
    internal class DocumentTypeInit : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.HasData(
           new DocumentType { Id = "0", Description = "Otros", Country = "PE" },
           new DocumentType { Id = "1",Description = "Documento Nacional de Identidad", Country = "PE" },
           new DocumentType { Id = "4", Description = "Carné de Extranjería", Country = "PE" },
           new DocumentType { Id = "7", Description = "Pasaporte", Country = "PE" },
           new DocumentType { Id = "F", Description = "Carné Permiso Temporal de Permanencia (PTP)", Country = "PE" }

            );
        }
    }
}
