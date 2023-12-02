using ColabManager360.Domain.Entities.Account;
using ColabManager360.Domain.Entities.Activity;
using ColabManager360.Domain.Entities.Business;
using ColabManager360.Domain.Entities.Client;
using ColabManager360.Domain.Entities.Collaborator;
using ColabManager360.Domain.Entities.Common;
using ColabManager360.Domain.Entities.Security.Models;
using ColabManager360.Domain.Entities.ServiceManager;
using ColabManager360.Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Attribute = ColabManager360.Domain.Entities.Common.Attribute;

namespace ColabManager360.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<Users, Roles, string, IdentityUserClaim<string>, UserRoles, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            // Configuración para todas las relaciones el comportamiento de borrado
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            #region Identity

            builder.Entity<IdentityUserClaim<string>>(b =>
                        {
                            b.ToTable("UserClaims");
                        });

            builder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
                b.ToTable("UserLogins");
            });

            builder.Entity<IdentityUserToken<string>>(b =>
            {
                b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
                b.ToTable("UserTokens");
            });

            builder.Entity<Roles>(b =>
            {
                b.ToTable("Roles");
            });

            builder.Entity<IdentityRoleClaim<string>>(b =>
            {
                b.ToTable("RoleClaims");
            });

            builder.Entity<UserRoles>(b =>
            {
                b.HasKey(ur => new { ur.UserId, ur.RoleId });

                b.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                b.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();


                //b.ToTable("UserRoles");
            });
            #endregion

            #region Actividades

            builder.Entity<Period>()
            .HasOne(p => p.StateMasterTable)
            .WithMany()
            .HasForeignKey(p => new { p.State })
            .HasPrincipalKey(md => new { md.ShortDesc });

            #endregion

            #region Personas



            #endregion

            #region Negocio
            builder.Entity<PersonIndustry>()
            .HasKey(pi => new { pi.IndustryId, pi.PersonId });

            //builder.Entity<PersonIndustry>()
            //    .HasOne(pi => pi.Industry)
            //    .WithMany(i => i.PersonIndustries)
            //    .HasForeignKey(pi => pi.IndustryId);

            //builder.Entity<PersonIndustry>()
            //    .HasOne(pi => pi.Person)
            //    .WithMany(p => p.PersonIndustries)
            //    .HasForeignKey(pi => pi.PersonId);

            builder.Entity<CostCenter>()
            .HasIndex(t => t.Code);

            builder.Entity<WorkAreaTeam>()
            .HasKey(wt => new { wt.Id, wt.WorkAreaId });
            #endregion

            #region Colaborador
            builder.Entity<Collaborator>()
            .HasMany(p => p.Schedules)
            .WithOne(s => s.Collaborator)    // Configuración de la propiedad de navegación en Horario
            .HasForeignKey(s => s.CollaboratorId);

            builder.Entity<CollaboratorContact>()
           .HasKey(cc => new { cc.CollaboratorId, cc.ContactServiceId });

            builder.Entity<CollaboratorCompany>()
            .HasKey(cc => new { cc.CollaboratorId, cc.CompanyId });

            #endregion

            #region Service Manager
            builder.Entity<ServiceManagerCollaborator>()
            .HasKey(sc => new { sc.ServiceManagerId, sc.CollaboratorId });

            builder.Entity<ServiceManagerCollaborator>().HasOne(ur => ur.ServiceManager)
                  .WithMany(r => r.ServiceManagerCollaborators)
                  .HasForeignKey(ur => ur.ServiceManagerId)
                  .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ServiceManagerCollaborator>().HasOne(ur => ur.Collaborator)
                .WithMany(r => r.ServiceManagerCollaborators)
                .HasForeignKey(ur => ur.CollaboratorId)
                .OnDelete(DeleteBehavior.NoAction);


            #endregion

            #region Security
            builder.Entity<MenuRoles>()
           .HasKey(mr => new { mr.MenuId, mr.RoleId });
            #endregion

            #region Comun
            builder.Entity<MasterDetailTable>()
            .HasKey(e => new { e.TableName, e.TableCode, e.ShortDesc });

            builder.Entity<MasterDetailTable>()
            .HasIndex(t => new { t.TableName, t.TableCode });

            #endregion

            #region Cliente
            //builder.Entity<CompanyService>()
            //.HasIndex(t => t.Company);
            #endregion


            #region Data Inicial
            builder.ApplyConfiguration(new RolesInit());
            builder.ApplyConfiguration(new UserInit());
            builder.ApplyConfiguration(new UserRoleInit());
            builder.ApplyConfiguration(new DocumentTypeInit());
            builder.ApplyConfiguration(new CountryInit());
            builder.ApplyConfiguration(new UbigeoInit());
            builder.ApplyConfiguration(new MenuGroupInit());
            builder.ApplyConfiguration(new MenuInit());
            builder.ApplyConfiguration(new MenuRoleInit());
            builder.ApplyConfiguration(new MasterDetailInit());
            builder.ApplyConfiguration(new ActivityTypeInit());
            builder.ApplyConfiguration(new CompanyInit());
            builder.ApplyConfiguration(new ServiceTypeInit());
            builder.ApplyConfiguration(new PeriodInit());
            builder.ApplyConfiguration(new WorkAreaInit());
            #endregion



            #region REPORTES   


            #endregion



        }

        #region TABLAS

        #region Personas
        public DbSet<PersonInformation> PersonInformation { get; set; }
        public DbSet<PersonHistory> PersonHistory { get; set; }
        public DbSet<PersonDocument> PersonDocuments { get; set; }
        public DbSet<PersonCertification> PersonCertifications { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }
      
        #endregion

        #region Comunes
        public DbSet<ActionType> ActionTypes { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<EntryType> EntryTypes { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Ubigeo> Ubigeo { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<MasterDetailTable> MasterDetailTable { get; set; }
        #endregion

        #region Colaborador
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<CollaboratorContact> CollaboratorContacts { get; set; }
        public DbSet<CollaboratorAdditionalInfo> CollaboratorAdditionalInfos { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<CollaboratorCompany> CollaboratorCompanies { get; set; }
        #endregion

        #region Service Manager
        public DbSet<ServiceManager> ServiceManagers { get; set; }
        public DbSet<ServiceManagerCollaborator> ServiceManagerCollaborators { get; set; }
        #endregion

        #region Clientes
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyArea> CompanyAreas { get; set; }
        public DbSet<CompanyAreaCollaborator> CompanyAreaCollaborators { get; set; }
        public DbSet<CompanyService> CompanyServices { get; set; }
        public DbSet<ContactService> ContactServices { get; set; }

        #endregion

        #region Actividades / Novedades
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityDetail> ActivitiesDetail { get; set; }
        public DbSet<Novelty> Novelties { get; set; }
        public DbSet<NoveltyRequest> NoveltyRequests { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Period> Periods { get; set; }
        #endregion

        #region Negocio
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<PersonIndustry> PersonIndustries { get; set; }
        public DbSet<CostCenter> CostCenter { get; set; }
        public DbSet<WorkArea> WorkAreas { get; set; }
        public DbSet<WorkAreaTeam> WorkAreaTeams { get; set; }
        #endregion

        #region Security
        public DbSet<MenuGroup> MenuGroup { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuRoles> MenuRole { get; set; }
        #endregion

        #endregion


        #region REPORTES




        #endregion


    }
}
