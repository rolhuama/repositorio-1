using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Common
{
    public class MasterDetailTable
    {
        [MaxLength(50)]
        public string TableName { get; set; }
        [MaxLength(50)]
        public string TableCode { get; set; }
        [MaxLength(25)]
        public string ShortDesc { get; set; }
        [MaxLength(255)]
        public string? LongDesc { get; set; }
        public decimal? DecimalValue { get; set; }
        public int? IntegerValue { get; set; }
        public bool? IsSystemTable { get; set; }
        public int? Order { get; set; }
    }
}
