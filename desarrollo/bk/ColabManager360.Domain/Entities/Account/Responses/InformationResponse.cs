using ColabManager360.Domain.Entities.Account.Requests;
using ColabManager360.Domain.Entities.Auth.Responses;

namespace ColabManager360.Domain.Entities.Account.Responses
{
    public class InformationResponse: RegisterRequest
    {
        public int CollaboratorId { get; set; }
        public virtual UserResponse User { get; set; }
    }
}
