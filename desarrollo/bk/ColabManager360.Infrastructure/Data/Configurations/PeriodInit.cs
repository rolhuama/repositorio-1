using ColabManager360.Domain.Entities.Activity;
using ColabManager360.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColabManager360.Infrastructure.Data.Configurations
{
    internal class PeriodInit : IEntityTypeConfiguration<Period>
    {
        public void Configure(EntityTypeBuilder<Period> builder)
        {

            var data = new List<Period>{};

            int year = DateTime.Now.Year;
            int actualMonth = DateTime.Now.Month;

            for (int m = actualMonth; m <= 12; m++)
            {
                var id = year.ToString("0000") + m.ToString("00");
                var MaximumDays = Utilities.CalculateBusinessDaysInMonth(year, actualMonth);

                data.Add(new Period { Id=id , Year =year, Month = m,Description="Periodo "+ m, State="A", MaximumDays= MaximumDays,MaximumHours= MaximumDays*8 });
            }


            builder.HasData(data);
        }
    }
}
