namespace ColabManager360.Domain.Entities.Collaborator.Responses
{
    public class CollaboratorListResponse
    {
        public int Id { get; set; }
        public Guid PersonUid { get; set; }
        public string? EntelgyCode { get; set; }
        public string FirstName1 { get; set; }
        public string FirstName2 { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public string WorkEmail { get; set; }
        public string? Position { get; set; }
        public string? WorkCellPhone { get; set; }

    }
}
