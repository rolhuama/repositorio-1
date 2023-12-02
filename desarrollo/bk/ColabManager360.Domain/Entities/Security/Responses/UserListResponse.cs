namespace ColabManager360.Domain.Entities.Security.Responses
{
    public class UserListResponse
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public bool LockoutEnabled { get; set; }
 
        public string FirstName1 { get; set; }
    
        public string FirstName2 { get; set; }
    
        public string LastName1 { get; set; }
    
        public string LastName2 { get; set; }
        public string RoleId { get; set; }

        public string RoleName { get; set; }

        public bool IsRegistered { get; set; }
    }
}
