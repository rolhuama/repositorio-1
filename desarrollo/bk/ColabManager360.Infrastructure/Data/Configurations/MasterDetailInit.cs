using ColabManager360.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabManager360.Infrastructure.Data.Configurations
{
    internal class MasterDetailInit : IEntityTypeConfiguration<MasterDetailTable>
    {
        public void Configure(EntityTypeBuilder<MasterDetailTable> builder)
        {
           
            var data = new List<MasterDetailTable>
            {
                new MasterDetailTable {TableName="Periods", TableCode="States", ShortDesc="A", LongDesc ="Habilitado"},
                new MasterDetailTable {TableName="Periods", TableCode="States", ShortDesc="B", LongDesc ="Bloqueado"}

            };

            builder.HasData(data);
        }
    }
}
