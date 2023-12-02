namespace ColabManager360.Domain.Entities.Auth.Requests
{
    public  class GoogleCredentialsRequest
    {
        public string clientId { get; set; }
        public string? client_id { get; set; }
        public string credential { get; set; }
        public string? select_by { get; set; }
    }
}
