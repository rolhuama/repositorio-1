using ColabManager360.Domain.Common;
using ColabManager360.Domain.Entities.Account;
using ColabManager360.Domain.Entities.Business;
using ColabManager360.Domain.Entities.Client;
using ColabManager360.Domain.Entities.ServiceManager;
using System.ComponentModel.DataAnnotations;

namespace ColabManager360.Domain.Entities.Collaborator
{
    public class Collaborator : BaseAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public PersonInformation Person { get; set; }
        public bool? Transversal { get; set; }

        public virtual WorkArea? WorkArea { get; set; }
        public virtual WorkAreaTeam? WorkAreaTeam { get; set; }

        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Activity.Activity> Activities { get; set; }
        public ICollection<CompanyAreaCollaborator> CompanyAreas { get; set; }
        public ICollection<CollaboratorContact> CollaboratorContacts { get; set; }
        public ICollection<ServiceManagerCollaborator> ServiceManagerCollaborators { get; set; }
        public ICollection<CollaboratorCompany> CollaboratorCompanies { get; set; }

    }
}
