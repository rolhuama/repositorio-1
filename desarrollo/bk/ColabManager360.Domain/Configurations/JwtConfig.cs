namespace ColabManager360.Domain.Configurations
{
    public class JwtConfig
    {
        public string Issuer { get; set; } = string.Empty; 
        public string Audience { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public int Expires { get; set; }
        public string CookieName { get; set; } = string.Empty;
    }
}
