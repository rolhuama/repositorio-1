namespace ColabManager360.Domain.Entities.Auth.Responses
{
    public class UserResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
        public string? FamilyName { get; set; }
        public string? GivenName { get; set; }
        public string? Picture { get; set; } = string.Empty;
        public string Role { get; set; }
        public bool? IsRegistered { get; set; }
        public string? PersonId { get; set; }
        public string? Position { get; set; }
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }

        public UserResponse()
        {
           
        }
        public UserResponse(string? familyName, string? givenName)
        {
            FamilyName = familyName;
            GivenName = givenName;
        }

    }
}
