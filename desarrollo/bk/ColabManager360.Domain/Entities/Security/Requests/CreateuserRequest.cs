namespace ColabManager360.Domain.Entities.Security.Requests
{
    public class CreateUserRequest
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string RoleId { get; set; }

        public bool LockoutEnabled { get; set; }
    }
}
