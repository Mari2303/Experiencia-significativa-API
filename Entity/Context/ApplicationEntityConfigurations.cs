using System.Reflection.Metadata;
using Entity.Models;
using Entity.Models.ModelosParametros;
using Entity.Models.ModuleGeographic;
using Entity.Models.ModuleOperation;
using Entity.Models.ModuleSegurity;
using Entity.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Context
{
    
    public class ApplicationEntityConfigurations :
        IEntityTypeConfiguration<User>,
        IEntityTypeConfiguration<Person>,
        IEntityTypeConfiguration<Role>,
        IEntityTypeConfiguration<Permission>,
        IEntityTypeConfiguration<Form>,
        IEntityTypeConfiguration<Module>,
        IEntityTypeConfiguration<UserRole>,
        IEntityTypeConfiguration<FormModule>,
        IEntityTypeConfiguration<RoleFormPermission>,
         IEntityTypeConfiguration<Criteria>,
         IEntityTypeConfiguration<StateExperience>,
         IEntityTypeConfiguration<Grade>,
         IEntityTypeConfiguration<LineThematic>,
         IEntityTypeConfiguration<PopulationGrade>,

        IEntityTypeConfiguration<Models.ModuleOperation.Document>,
        IEntityTypeConfiguration<Experience>,
        IEntityTypeConfiguration<ExperienceLineThematic>,
        IEntityTypeConfiguration<ExperienceGrade>,
        IEntityTypeConfiguration<Objective>,
        IEntityTypeConfiguration<ExperiencePopulation>,
        IEntityTypeConfiguration<Evaluation>,
        IEntityTypeConfiguration<HistoryExperience>,
        IEntityTypeConfiguration<Development>,
        IEntityTypeConfiguration<Institution>,
        IEntityTypeConfiguration<EvaluationCriteria>,
        IEntityTypeConfiguration<PasswordRecovery>,

        IEntityTypeConfiguration<Leader>,
        IEntityTypeConfiguration<Monitoring>,
        IEntityTypeConfiguration<SupportInformation>,

        IEntityTypeConfiguration<Departament>,
        IEntityTypeConfiguration<Municipality>,
        IEntityTypeConfiguration<Commune>,
        IEntityTypeConfiguration<EEZone>,
        IEntityTypeConfiguration<Address>,

        IEntityTypeConfiguration<ExperienceEditPermission>





    {

        public void Configure(EntityTypeBuilder<ExperienceEditPermission> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(e => e.Experience)
                   .WithMany()
                   .HasForeignKey(e => e.ExperienceId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.User)
                   .WithMany()
                   .HasForeignKey(e => e.UserId)
                   .OnDelete(DeleteBehavior.Restrict); 
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(s => s.Id); // Primary key
        }


        public void Configure(EntityTypeBuilder<PasswordRecovery> builder)
        {
            builder.HasKey(s => s.Id); 
        }

        /// <summary>
        /// Configura la entidad User.
        /// Define la clave primaria para la entidad User.
        /// </summary>
        /// <param name="builder">El constructor utilizado para configurar la entidad.</param>

        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(s => s.Id); // Primary key
        }
        /// <summary>
        /// Configura la entidad Role.
        /// Define la clave primaria para la entidad Role.
        /// </summary>
        /// <param name="builder">El constructor utilizado para configurar la entidad.</param>

        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(s => s.Id); // Primary key
        }

        public void Configure(EntityTypeBuilder<Criteria> builder)
        {
            builder.HasKey(s => s.Id); // Primary key
        }


        public void Configure(EntityTypeBuilder<StateExperience> builder)
        {
            builder.HasKey(s => s.Id); // Primary key

        }

        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(s => s.Id); // Primary key
        }


        public void Configure(EntityTypeBuilder<LineThematic> builder)
        {
            builder.HasKey(s => s.Id); // Primary key
        }


        public void Configure(EntityTypeBuilder<PopulationGrade> builder)
        {
            builder.HasKey(s => s.Id); // Primary key
        }

        /// <summary>
        /// Configura la entidad Permission.
        /// Define la clave primaria para la entidad Permission.
        /// </summary>
        /// <param name="builder">El constructor utilizado para configurar la entidad.</param>

        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(s => s.Id); // Primary key
        }
        /// <summary>
        /// Configura la entidad Form.
        /// Define la clave primaria para la entidad Form.
        /// </summary>
        /// <param name="builder">El constructor utilizado para configurar la entidad.</param>

        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.HasKey(s => s.Id); // Primary key
        }
        /// <summary>
        /// Configura la entidad Module.
        /// Define la clave primaria para la entidad Module.
        /// </summary>
        /// <param name="builder">El constructor utilizado para configurar la entidad.</param>

        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.HasKey(s => s.Id); // Primary key
        }
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId); //UserId

            builder.HasOne(ur => ur.Role)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.RoleId); //RoleId
        }
        public void Configure(EntityTypeBuilder<FormModule> builder)
        {
            builder.HasOne(fm => fm.Form)
                .WithMany(f => f.FormModules)
                .HasForeignKey(fm => fm.FormId); //FormId

            builder.HasOne(fm => fm.Module)
                .WithMany(f => f.FormModules)
                .HasForeignKey(fm => fm.ModuleId); //ModuleId
        }
        public void Configure(EntityTypeBuilder<RoleFormPermission> builder)
        {
            builder.HasOne(rfp => rfp.Role)
                .WithMany(r => r.RoleFormPermissions)
                .HasForeignKey(rfp => rfp.RoleId); //RoleId

            builder.HasOne(rfp => rfp.Form)
                .WithMany(r => r.RoleFormPermissions)
                .HasForeignKey(rfp => rfp.FormId); //FormId

            builder.HasOne(rfp => rfp.Permission)
                .WithMany(r => r.RoleFormPermissions)
                .HasForeignKey(rfp => rfp.PermissionId); //PermissionId
        }


        public void Configure(EntityTypeBuilder<Models.ModuleOperation.Document> builder)
        {
            builder.HasOne(rfp => rfp.Experience)
                .WithMany(r => r.Documents)
                .HasForeignKey(rfp => rfp.ExperienceId);
        }

        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder.HasOne(rfp => rfp.Experience)
                .WithMany(r => r.Evaluations)
                .HasForeignKey(rfp => rfp.ExperienceId);

            builder.HasOne(rfp => rfp.User)
        .WithMany(r => r.Evaluations)
        .HasForeignKey(rfp => rfp.UserId)
        .OnDelete(DeleteBehavior.Restrict); // Evita cascada automática

        }


        public void Configure(EntityTypeBuilder<EvaluationCriteria> builder)
        {
            builder.HasOne(rfp => rfp.Evaluation)
                .WithMany(r => r.EvaluationCriterias)
                .HasForeignKey(rfp => rfp.EvaluationId);

            builder.HasOne(rfp => rfp.Criteria)
                .WithMany(r => r.EvaluationCriterias)
                .HasForeignKey(rfp => rfp.CriteriaId);
        }

        public void Configure(EntityTypeBuilder<Experience> builder)
        {

            builder.HasOne(e => e.User)
                .WithMany(u => u.Experiences)
                .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.Institution)
                .WithMany(i => i.Experiences)
                .HasForeignKey(e => e.InstitucionId);

            builder.HasOne(e => e.StateExperience)
                .WithMany(i => i.Experiences)
                .HasForeignKey(e => e.StateExperienceId);

        }

        public void Configure(EntityTypeBuilder<ExperienceLineThematic> builder)
        {
            builder.HasOne(e => e.Experience)
                .WithMany(u => u.ExperienceLineThematics)
                .HasForeignKey(e => e.ExperienceId);

            builder.HasOne(e => e.LineThematic)
                .WithMany(i => i.ExperienceLineThematics)
                .HasForeignKey(e => e.LineThematicId);
        }

        public void Configure(EntityTypeBuilder<ExperienceGrade> builder)
        {
            builder.HasOne(e => e.Experience)
                .WithMany(u => u.ExperienceGrades)
                .HasForeignKey(e => e.ExperienceId);

            builder.HasOne(e => e.Grade)
                .WithMany(i => i.ExperienceGrades)
                .HasForeignKey(e => e.GradeId);
        }

        public void Configure(EntityTypeBuilder<Objective> builder)
        {
            builder.HasOne(e => e.Experience)
                .WithMany(u => u.Objectives)
                .HasForeignKey(e => e.ExperienceId);
        }

        public void Configure(EntityTypeBuilder<ExperiencePopulation> builder)
        {
            builder.HasOne(e => e.Experience)
                .WithMany(u => u.ExperiencePopulations)
                .HasForeignKey(e => e.ExperienceId);

            builder.HasOne(e => e.PopulationGrade)
                .WithMany(i => i.ExperiencePopulations)
                .HasForeignKey(e => e.PopulationGradeId);
        }

        public void Configure(EntityTypeBuilder<HistoryExperience> builder)
        {
            builder.HasOne(h => h.User)
        .WithMany(u => u.HistoryExperiences)
        .HasForeignKey(h => h.UserId)
        .OnDelete(DeleteBehavior.Restrict); // Evita cascada

            builder.HasOne(h => h.Experience)
                   .WithMany(e => e.HistoryExperiences)
                   .HasForeignKey(h => h.ExperienceId)
                   .OnDelete(DeleteBehavior.Cascade); // Solo esta puede ser cascade

          


        }
        public void Configure(EntityTypeBuilder<Development> builder)
        {
            builder.HasOne(e => e.Experience)
                .WithMany(u => u.Developments)
                .HasForeignKey(e => e.ExperienceId);


        }
        public void Configure(EntityTypeBuilder<Institution> builder)
        {
            builder.HasKey(s => s.Id); // Primary key



        }

        public void Configure(EntityTypeBuilder<Leader> builder)
        {
            builder.HasOne(e => e.Experience)
                .WithMany(u => u.Leaders)
                .HasForeignKey(e => e.ExperienceId);
        }

        public void Configure(EntityTypeBuilder<Monitoring> builder)
        {
            builder.HasOne(e => e.Objective)
                .WithMany(u => u.Monitorings)
                .HasForeignKey(e => e.ObjectiveId);

        }

        public void Configure(EntityTypeBuilder<SupportInformation> builder)
        {
            builder.HasOne(e => e.Objective)
                .WithMany(u => u.SupportInformations)
                .HasForeignKey(e => e.ObjectiveId);
        }

        public void Configure(EntityTypeBuilder<Departament> builder)
        {
            builder.HasOne(e => e.Institution)
                .WithMany(u => u.Departaments)
                .HasForeignKey(e => e.InstitutionId);
        }

        public void Configure(EntityTypeBuilder<Municipality> builder)
        {
            builder.HasOne(e => e.Institution)
                .WithMany(u => u.Municipalitis)
                .HasForeignKey(e => e.InstitutionId);
        }

        public void Configure(EntityTypeBuilder<Commune> builder)
        {
            builder.HasOne(e => e.Institution)
                .WithMany(u => u.Communes)
                .HasForeignKey(e => e.InstitutionId);

        }


        public void Configure(EntityTypeBuilder<EEZone> builder)
        {
            builder.HasOne(e => e.Institution)
                .WithMany(u => u.EEZones)
                .HasForeignKey(e => e.InstitutionId);
        }

        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasOne(e => e.Institution)
                .WithMany(u => u.Addresss)
                .HasForeignKey(e => e.InstitutionId);
        }

     




        }
}