using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Account.Requests
{
    public class RegisterRequest
    {
        public string FirstName1 { get; set; }

        public string FirstName2 { get; set; }

        public string LastName1 { get; set; }

        public string LastName2 { get; set; }
        public string DocumentTypeId { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime Birthday { get; set; }

        public string PersonalEmail { get; set; }
        public string WorkEmail { get; set; }

        public string PersonalCellPhone { get; set; }

        public string WorkCellPhone { get; set; }
        public string Gender { get; set; }

        public string Address { get; set; }
        public string ReferenceAddress { get; set; }
        [MaxLength(10)]
        public string District { get; set; }
        [MaxLength(10)]
        public string Province { get; set; }
        [MaxLength(10)]
        public string Department { get; set; }
        public string Nationality { get; set; }
        public bool HasChildren { get; set; }


    }
}
