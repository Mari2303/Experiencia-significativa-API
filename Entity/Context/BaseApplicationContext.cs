using Dapper;
using Entity.Models;
using Entity.Models.ModelosParametros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Storage;
using Entity.Models.ModuleOperation;
using Entity.Models.ModuleGeographic;
using Entity.Models.ModuleSegurity;

namespace Entity.Context
{
    /// <summary>
    /// DbContext base para reutilizar entidades, configuraciones y métodos comunes
    /// </summary>
    public abstract class BaseApplicationContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        protected BaseApplicationContext(DbContextOptions options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var configuration = new ApplicationEntityConfigurations();
            modelBuilder.ApplyConfiguration<User>(configuration);
            modelBuilder.ApplyConfiguration<Person>(configuration);
            modelBuilder.ApplyConfiguration<Role>(configuration);
            modelBuilder.ApplyConfiguration<Permission>(configuration);
            modelBuilder.ApplyConfiguration<Form>(configuration);
            modelBuilder.ApplyConfiguration<Models.ModuleSegurity.Module>(configuration);
            modelBuilder.ApplyConfiguration<UserRole>(configuration);
            modelBuilder.ApplyConfiguration<FormModule>(configuration);
            modelBuilder.ApplyConfiguration<RoleFormPermission>(configuration);
            modelBuilder.ApplyConfiguration<StateExperience>(configuration);
            modelBuilder.ApplyConfiguration<Grade>(configuration);
            modelBuilder.ApplyConfiguration<Criteria>(configuration);
            modelBuilder.ApplyConfiguration<LineThematic>(configuration);
            modelBuilder.ApplyConfiguration<PopulationGrade>(configuration);



            modelBuilder.ApplyConfiguration<Document>(configuration);
            modelBuilder.ApplyConfiguration<Development>(configuration);
            modelBuilder.ApplyConfiguration<Evaluation>(configuration);
            modelBuilder.ApplyConfiguration<EvaluationCriteria>(configuration);
            modelBuilder.ApplyConfiguration<Experience>(configuration);
            modelBuilder.ApplyConfiguration<ExperienceGrade>(configuration);
            modelBuilder.ApplyConfiguration<ExperienceLineThematic>(configuration);
            modelBuilder.ApplyConfiguration<ExperiencePopulation>(configuration);
            modelBuilder.ApplyConfiguration<HistoryExperience>(configuration);
            modelBuilder.ApplyConfiguration<Institution>(configuration);
            modelBuilder.ApplyConfiguration<Objective>(configuration);

            modelBuilder.ApplyConfiguration<Leader>(configuration);
            modelBuilder.ApplyConfiguration<Monitoring>(configuration);
            modelBuilder.ApplyConfiguration<SupportInformation>(configuration);
            modelBuilder.ApplyConfiguration<Departament>(configuration);
            modelBuilder.ApplyConfiguration<Commune>(configuration);
            modelBuilder.ApplyConfiguration<Address>(configuration);
            modelBuilder.ApplyConfiguration<Municipality>(configuration);
            modelBuilder.ApplyConfiguration<EEZone>(configuration);


            modelBuilder.Entity<PasswordRecovery>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Code).IsRequired().HasMaxLength(10);
                entity.Property(e => e.Expiration).IsRequired();
                entity.Property(e => e.Active).IsRequired();
            });

            InitialData.Data(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            EnsureAudit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();
        }

        // Métodos Dapper
        public async Task<IEnumerable<T>> QueryAsync<T>(string text, object parameters = null!, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryAsync<T>(command.Definition);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string text, object parameters = null!, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }

        public readonly struct DapperEFCoreCommand : IDisposable
        {
            public CommandDefinition Definition { get; }

            public DapperEFCoreCommand(DbContext context, string text, object parameters, int? timeout, CommandType? type, CancellationToken ct)
            {
                var transaction = context.Database.CurrentTransaction?.GetDbTransaction();
                var commandType = type ?? CommandType.Text;
                var commandTimeout = timeout ?? context.Database.GetCommandTimeout() ?? 30;

                Definition = new CommandDefinition(
                    text,
                    parameters,
                    transaction,
                    commandTimeout,
                    commandType,
                    cancellationToken: ct
                );
            }

            public void Dispose() { }
        }

        // DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormModule> FormModules { get; set; }
        public DbSet<RoleFormPermission> RoleFormPermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Models.ModuleSegurity.Module> Modules { get; set; }
        public DbSet<StateExperience> StateExperiences { get; set; }
        public DbSet<Criteria> Criteria { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<LineThematic> LineThematics { get; set; }
        public DbSet<PopulationGrade> PopulationGrade { get; set; }

      
        public DbSet<Models.ModuleOperation.Document> Documents { get; set; }
        public DbSet<Development> Development { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<EvaluationCriteria> EvaluationCriterias { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<ExperienceGrade> ExperienceGrades { get; set; }
        public DbSet<ExperienceLineThematic> ExperienceLineThematics { get; set; }
        public DbSet<ExperiencePopulation> ExperiencePopulation { get; set; }
        public DbSet<HistoryExperience> HistoryExperiences { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<PasswordRecovery> PasswordRecoveries { get; set; } = null!;


        public DbSet<Leader> Leaders { get; set; }
        public DbSet<Monitoring> Monitorings { get; set; }
        public DbSet<SupportInformation> SupportInformations { get; set; }
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Commune> Communes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<EEZone> EEZones { get; set; }

    }

    // DbContext concreto para cada base de datos
    public class ApplicationContextSQL : BaseApplicationContext
    {
        public ApplicationContextSQL(DbContextOptions<ApplicationContextSQL> options, IConfiguration configuration)
            : base(options, configuration) { }
    }

    public class ApplicationContextPostgres : BaseApplicationContext
    {
        public ApplicationContextPostgres(DbContextOptions<ApplicationContextPostgres> options, IConfiguration configuration)
            : base(options, configuration) { }
    }
    public class ApplicationContextMySQL : BaseApplicationContext
    {
        public ApplicationContextMySQL(DbContextOptions<ApplicationContextMySQL> options, IConfiguration configuration)
            : base(options, configuration) { }
    } 
}
