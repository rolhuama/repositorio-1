using ColabManager360.Domain.Entities.Common;

namespace ColabManager360.Domain.Entities.Helper.Responses
{
    public class AccountListResponse
    {
        public ICollection<DocumentType> DocumentTypes { get; set; }
        public ICollection<Country> Countries { get; set; }
        public ICollection<Ubigeo> Departments { get; set; }
    }
}
