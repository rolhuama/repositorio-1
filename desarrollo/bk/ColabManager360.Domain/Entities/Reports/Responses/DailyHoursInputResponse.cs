using Microsoft.EntityFrameworkCore;

namespace ColabManager360.Domain.Entities.Reports.Responses
{
    // Definir la clase de la entidad sin clave
    //[Keyless]
    public class DailyHoursInputResponse
    {
        public string PeriodId { get; set; }
        public int MaximumDays { get; set; }
        public int MaximumHours { get; set; }
        public string LegalName { get; set; }
        public string CommercialName { get; set; }
        public string CountryName { get; set; }
        public string WorkAreaName { get; set; }
        public string WorkAreaTeamName { get; set; }
        public string ActivityTypeName { get; set; }
        public string CompanyServiceName { get; set; }
        public string FullLastName { get; set; }
        public string FullFirstName { get; set; }
        public string Description { get; set; }
        public decimal DurationHours { get; set; }
        public string TicketCode { get; set; }
    }
}
