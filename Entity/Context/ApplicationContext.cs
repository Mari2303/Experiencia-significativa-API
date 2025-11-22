using Dapper;
using Entity.Models;
using Entity.Models.ModelosParametros;
using Entity.Models.ModuleGeographic;
using Entity.Models.ModuleOperation;
using Entity.Models.ModuleSegurity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Entity.Context
{
    /// <summary>
    /// Contexto principal de la base de datos que gestiona usuarios, roles, permisos, personas, clientes, evaluaciones,
    /// módulos, documentos, instituciones, objetivos y demás entidades del sistema.
    /// Combina EF Core para ORM y Dapper para queries directas SQL.
    /// </summary>
    public class ApplicationContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor del ApplicationContext.
        /// </summary>
        /// <param name="options">Opciones del contexto de EF Core.</param>
        /// <param name="configuration">Objeto de configuración (para obtener connection strings, etc).</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Configura los modelos y relaciones entre las entidades.
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder de EF Core.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica todas las configuraciones de entidades desde este ensamblado
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Configuración específica de cada entidad mediante ApplicationEntityConfigurations
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
            modelBuilder.ApplyConfiguration<Models.ModuleOperation.Document>(configuration);
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

            modelBuilder.ApplyConfiguration<ExperienceEditPermission>(configuration);


            // Configuración específica de PasswordRecovery
            modelBuilder.Entity<PasswordRecovery>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Code).IsRequired().HasMaxLength(10);
                entity.Property(e => e.Expiration).IsRequired();
                entity.Property(e => e.Active).IsRequired();
            });

            // Carga de datos
             InitialData.Data(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Configura EF Core para permitir logging de datos sensibles (para debug).
        /// Ignora warnings de cambios pendientes en el modelo.
        /// </summary>
        /// <param name="optionsBuilder">Opciones del contexto.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        /// <summary>
        /// Sobrescribe SaveChanges para incluir lógica de auditoría antes de persistir cambios.
        /// </summary>
        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }

        /// <summary>
        /// Sobrescribe SaveChangesAsync para incluir lógica de auditoría de forma asíncrona.
        /// </summary>
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            EnsureAudit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        /// <summary>
        /// Detecta cambios en las entidades antes de guardar, útil para auditoría.
        /// </summary>
        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();
        }

        #region Dapper Support

        /// <summary>
        /// Ejecuta un query SQL usando Dapper y devuelve un IEnumerable del tipo especificado.
        /// </summary>
        public async Task<IEnumerable<T>> QueryAsync<T>(string text, object parameters = null!, int? timeout = null, CommandType? type = null, string? Role = null, int? UserId = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryAsync<T>(command.Definition);
        }

        /// <summary>
        /// Ejecuta un query SQL usando Dapper y devuelve el primer objeto encontrado o valor por defecto.
        /// </summary>
        public async Task<T> QueryFirstOrDefaultAsync<T>(string text, object parameters = null!, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }

        /// <summary>
        /// Representa un comando SQL para Dapper y EF Core con soporte de transacciones, timeout y token de cancelación.
        /// </summary>
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

        #endregion

        #region DbSets

        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ExperienceEditPermission> ExperienceEditPermissions { get; set; }
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


        #endregion
    }
}

