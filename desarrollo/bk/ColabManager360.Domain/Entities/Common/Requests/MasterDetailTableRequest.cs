using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Common.Requests
{
    public  class MasterDetailTableRequest
    {
        [MaxLength(50)]
        public string TableName { get; set; }
        [MaxLength(50)]
        public string TableCode { get; set; }
    }
}
