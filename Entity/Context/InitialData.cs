using Entity.Models;
using Entity.Models.ModuleSegurity;
using Microsoft.EntityFrameworkCore;

namespace Entity.Context
{
    internal class InitialData
    {
        public static void Data(ModelBuilder modelBuilder)
        {
            DateTime currentDate = DateTime.UtcNow.AddHours(-5);
            InitialDataLineThematic.Seed(modelBuilder, currentDate);
            InitialDataState.Seed(modelBuilder, currentDate);
            InitialDataCriteria.Seed(modelBuilder, currentDate);
            InitialDataPopulationGrade.Seed(modelBuilder, currentDate);
            InitialDataGrade.Seed(modelBuilder, currentDate);

            // Roles
            var roleAdmin = new Role()
            {
                Id = 1,
                Code = "01",
                Name = "SUPERADMIN",
                Description = "",
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var roleTeacher = new Role()
            {
                Id = 2,
                Code = "0002",
                Name = "Profesor",
                Description = "Rol para profesores",
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<Role>().HasData(roleAdmin, roleTeacher);

            // Persons
            var leader = new Person()
            {
                Id = 1,
                DocumentType = 1,
                IdentificationNumber = "1000000000",
                FirstName = "MARIA",
                MiddleName = "ALEJANDRA",
                FirstLastName = "MARIN",
                SecondLastName = "HENRIQUEZ",
                Email = "mariaalejan1080@gmail.com",
                EmailInstitutional = "mariaa_marinh@soy.sena.com",
                CodeDane = "441001004839",
                CreatedAt = currentDate,
                Phone = 3243652328,
                State = true,
            };
            var teacherPerson = new Person()
            {
                Id = 2,
                DocumentType = 1,
                IdentificationNumber = "2000000000",
                FirstName = "JUAN",
                MiddleName = "CARLOS",
                FirstLastName = "PEREZ",
                SecondLastName = "GOMEZ",
                Email = "catalina2005cometa@gmail.com",
                EmailInstitutional = "catalina@soy.sena.com",
                CodeDane = "441001004840",
                CreatedAt = currentDate,
                Phone = 3123456789,
                State = true,
            };
            modelBuilder.Entity<Person>().HasData(leader, teacherPerson);

            // Users
            var userleader = new User()
            {
                Id = 1,
                Code = "0001",
                Username = "mariaalejan1080@gmail.com",
                PersonId = 1,
                Password = "202CB962AC59075B964B07152D234B70", // 123
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var teacherUser = new User()
            {
                Id = 2,
                Code = "0002",
                Username = "juan.perez@correo.com",
                PersonId = 2,
                Password = "202CB962AC59075B964B07152D234B70", // 123
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<User>().HasData(userleader, teacherUser);

            // Users - Roles
            var userRolLeader = new UserRole()
            {
                Id = 1,
                UserId = userleader.Id,
                RoleId = roleAdmin.Id,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var userRoleTeacher = new UserRole()
            {
                Id = 2,
                UserId = teacherUser.Id,
                RoleId = roleTeacher.Id,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<UserRole>().HasData(userRolLeader, userRoleTeacher);

            // Modules
            var moduleSecurity = new Module()
            {
                Id = 1,
                Name = "Security",
                Description = "El módulo de seguridad gestiona autenticación, roles, permisos y acceso a los formularios del sistema.",
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var moduleOperational = new Module()
            {
                Id = 2,
                Name = "Operational",
                Description = "El módulo operativo gestiona los formularios funcionales principales del sistema.",
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var moduleParameter = new Module()
            {
                Id = 3,
                Name = "Parametrización",
                Description = "El módulo de parametrización gestiona los formularios que controlan el comportamiento general del sistema.",
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<Module>().HasData(moduleSecurity, moduleOperational, moduleParameter);

            // Forms
            var formInicio = new Form()
            {
                Id = 1,
                Name = "Inicio",
                Path = "dashboard",
                Description = "Vista principal del sistema.",
                Icon = "fa-solid fa-house",
                Order = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formExperiencia = new Form()
            {
                Id = 2,
                Name = "Experiencia",
                Path = "experiences",
                Description = "Gestión de experiencias significativas.",
                Icon = "fa-solid fa-star",
                Order = 2,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formEvaluacion = new Form()
            {
                Id = 3,
                Name = "Evaluación",
                Path = "evaluation",
                Description = "Gestión de evaluaciones.",
                Icon = "fa-solid fa-clipboard-check",
                Order = 3,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formRoles = new Form()
            {
                Id = 4,
                Name = "Roles",
                Path = "roles",
                Description = "Gestión de roles del sistema.",
                Icon = "fa-solid fa-users-gear",
                Order = 5,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formUsers = new Form()
            {
                Id = 5,
                Name = "Usuarios",
                Path = "users",
                Description = "Gestión de usuarios.",
                Icon = "fa-solid fa-users",
                Order = 6,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formPersons = new Form()
            {
                Id = 6,
                Name = "Personas",
                Path = "persons",
                Description = "Gestión de personas.",
                Icon = "fa-solid fa-user",
                Order = 7,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var formSeguimiento = new Form()
            {
                Id = 7,
                Name = "Seguimiento",
                Path = "tracking",
                Description = "Formulario de seguimiento.",
                Icon = "fa-solid fa-building-user",
                Order = 4,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var formPermissions = new Form()
            {
                Id = 8,
                Name = "Permisos",
                Path = "permissions",
                Description = "Allows you to assign specific permissions to users and roles, controlling access to functions, forms, and modules according to the system's needs and security policies.",
                Icon = "fa-solid fa-user-lock",
                Order = 8,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModules = new Form()
            {
                Id = 9,
                Name = "Modulos",
                Path = "modules",
                Description = "Manages system modules, allowing users to define, modify, and assign modules available to them based on established roles and permissions.",
                Icon = "fa-solid fa-window-maximize",
                Order = 9,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var forms = new Form()
            {
                Id = 10,
                Name = "Formularios",
                Path = "forms",
                Description = "Manages the forms available in the system, allowing the creation, modification, and deletion of forms associated with different functionalities and modules.",
                Icon = "fa-solid fa-window-restore",
                Order = 10,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var formUsersRol = new Form()
            {
                Id = 11,
                Name = "Asignación de Roles",
                Path = "usersRol",
                Description = "Gestiona los roles de usuario dentro del sistema, permitiendo la asignación, modificación y eliminación de permisos según las responsabilidades y niveles de acceso de cada usuario.",
                Icon = "fa-solid fa-window-restore",
                Order = 11,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var formFormModule = new Form()
            {
                Id = 12,
                Name = "Asignación de Formularios",
                Path = "formModule",
                Description = "Gestiona la relación entre formularios y módulos del sistema, permitiendo organizar, vincular y estructurar los formularios dentro de las diferentes secciones o áreas funcionales.",
                Icon = "fa-solid fa-window-restore",
                Order = 12,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var formRolFormPermission = new Form()
            {
                Id = 13,
                Name = "Asignación por permisos",
                Path = "rolFormPermission",
                Description = "Gestiona la relación entre roles y formularios del sistema, permitiendo definir, organizar y controlar los permisos de acceso y acciones que cada rol puede realizar sobre los diferentes formularios.",
                Icon = "fa-solid fa-window-restore",
                Order = 13,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var formCriteria = new Form()
            {
                Id = 14,
                Name = "Asignación de Criterios",
                Path = "criteria",
                Description = "Formulario de Criterios",
                Icon = "fa-solid fa-window-restore",
                Order = 14,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var formGrade = new Form()
            {
                Id = 15,
                Name = "Asignación de Grados",
                Path = "grade",
                Description = "Formulario de Grados",
                Icon = "fa-solid fa-window-restore",
                Order = 15,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var formLineThematic = new Form()
            {
                Id = 16,
                Name = "Asignación de Líneas Temáticas",
                Path = "lineThematic",
                Description = "Formulario de Líenas Temáticas",
                Icon = "fa-solid fa-window-restore",
                Order = 16,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var formPopulationGrade = new Form()
            {
                Id = 17,
                Name = "Asignación de Grupo Poblacional",
                Path = "populationGrade",
                Description = "Formulario de grupo poblacional",
                Icon = "fa-solid fa-window-restore",
                Order = 17,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var formState = new Form
            {
                Id = 18,
                Name = "Asignación de Estado",
                Path = "state",
                Description = "Formulario del estado",
                Icon = "fa-solid fa-window-restore",
                Order = 18,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var formExpe = new Form
            {
                Id = 19,
                Name = "gestion experiencia",
                Path = "experiensGestion",
                Description = "permite hacer el seguimiento de edicion de los formularios",
                Icon = "fa-solid fa-window-restore",
                Order = 19,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };


            modelBuilder.Entity<Form>().HasData(formInicio, formExperiencia, formEvaluacion, formRoles, formUsers, formPersons, formSeguimiento, forms, formModules,
                formPermissions, formUsersRol, formFormModule, formRolFormPermission, formCriteria, formGrade, formLineThematic, formPopulationGrade, formState, formExpe);

            // Form - Modules
            var formModuleInicio = new FormModule()
            {
                Id = 1,
                FormId = 1, // Inicio
                ModuleId = 2, // Operational
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var formModuleExperiencia = new FormModule()
            {
                Id = 2,
                FormId = 2, // Experiencia
                ModuleId = 2, // Operational
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleEvaluacion = new FormModule()
            {
                Id = 3,
                FormId = 3, // Evaluación
                ModuleId = 2, // Operational
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleRoles = new FormModule()
            {
                Id = 4,
                FormId = 4, // Roles
                ModuleId = 1, // Security
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleUsers = new FormModule()
            {
                Id = 5,
                FormId = 5, // Users
                ModuleId = 1, // Security
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModulePersons = new FormModule()
            {
                Id = 6,
                FormId = 6, // Persons
                ModuleId = 1, // Security
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleSeguimiento = new FormModule()
            {
                Id = 7,
                FormId = 7, // Seguimiento
                ModuleId = 2, // Operational
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var formModulePermissions = new FormModule()
            {
                Id = 8,
                FormId = 8,// Permission 
                ModuleId = 1, // security
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleModules = new FormModule()
            {
                Id = 9,
                FormId = 9,
                ModuleId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleForms = new FormModule()
            {
                Id = 10,
                FormId = 10,
                ModuleId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleUsersRol = new FormModule()
            {
                Id = 11,
                FormId = 11,
                ModuleId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleFormModule = new FormModule()
            {
                Id = 12,
                FormId = 12,
                ModuleId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleRolFormPermissions = new FormModule()
            {
                Id = 13,
                FormId = 13,
                ModuleId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
           

            var formModuleCriteria = new FormModule()
            {
                Id = 14,
                FormId = 14,
                ModuleId = 3,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleGrade = new FormModule()
            {
                Id = 15,
                FormId = 15,
                ModuleId = 3,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleLineThematic = new FormModule()
            {
                Id = 16,
                FormId = 16,
                ModuleId = 3,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModulePopulationGrade = new FormModule()
            {
                Id = 17,
                FormId = 17,
                ModuleId = 3,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleState = new FormModule()
            {
                Id = 18,
                FormId = 18,
                ModuleId = 3,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var formModuleExpe = new FormModule()
            {
                Id = 19,
                FormId = 19,
                ModuleId = 2,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            modelBuilder.Entity<FormModule>().HasData(formModuleInicio, formModuleExperiencia, formModuleEvaluacion, formModuleRoles, formModuleUsers, formModulePersons,
                formModuleSeguimiento, formModulePermissions, formModuleForms, formModuleModules, formModuleUsersRol, formModuleFormModule, formModuleRolFormPermissions,
                formModuleCriteria, formModuleGrade, formModuleLineThematic, formModulePopulationGrade, formModuleState, formModuleExpe);

            // Permission
            var permissionReadWrite = new Permission()
            {
                Id = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!,
                Code = "0001",
                Name = "Reading and writing",
                Description = "Allows the user to query, update, and delete records within the system, granting full access to the management of associated data.",
            };
            var permissionReadOnly = new Permission()
            {
                Id = 2,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!,
                Code = "0002",
                Name = "Reading only",
                Description = "Allows the user to only view records within the system, without permission to perform updates or deletions.",
            };
            modelBuilder.Entity<Permission>().HasData(permissionReadWrite, permissionReadOnly);

            // Roles - Forms - Permissions (SUPERADMIN)
            var RoleFormPermissionInicio = new RoleFormPermission()
            {
                Id = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!,
                RoleId = 1,
                FormId = 1,
                PermissionId = 1,
            };
            var RoleFormPermissionExperiencia = new RoleFormPermission()
            {
                Id = 2,
                RoleId = 1,
                FormId = 2,
                PermissionId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var RoleFormPermissionEvaluacion = new RoleFormPermission()
            {
                Id = 3,
                RoleId = 1,
                FormId = 3,
                PermissionId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var RoleFormPermissionRoles = new RoleFormPermission()
            {
                Id = 4,
                RoleId = 1,
                FormId = 4,
                PermissionId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var RoleFormPermissionUsers = new RoleFormPermission()
            {
                Id = 5,
                RoleId = 1,
                FormId = 5,
                PermissionId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var RoleFormPermissionPersons = new RoleFormPermission()
            {
                Id = 6,
                RoleId = 1,
                FormId = 6,
                PermissionId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var RoleFormPermissionSeguimiento = new RoleFormPermission()
            {
                Id = 7,
                RoleId = 1,
                FormId = 7,
                PermissionId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var RoleFormPermissionPermissions = new RoleFormPermission()
            {
                Id = 8,
                RoleId = 1,
                FormId = 8,
                PermissionId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var RoleFormPermissionForms = new RoleFormPermission()
            {
                Id = 9,
                RoleId = 1,
                FormId = 9,
                PermissionId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var RoleFormPermissionModules = new RoleFormPermission()
            {
                Id = 10,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!,
                RoleId = 1,
                FormId = 10,
                PermissionId = 1,
            };

            var RoleFormPermissionUsersRol = new RoleFormPermission()
            {
                Id = 13,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!,
                RoleId = 1,
                FormId = 11,
                PermissionId = 1,
            };

            var RoleFormPermissionFormModule = new RoleFormPermission()
            {
                Id = 14,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!,
                RoleId = 1,
                FormId = 12,
                PermissionId = 1,
            };

            var RoleFormPermissionRolFormPermission = new RoleFormPermission()
            {
                Id = 15,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!,
                RoleId = 1,
                FormId = 13,
                PermissionId = 1,
            };

            var RoleFormPermissionCriteria = new RoleFormPermission()
            {
                Id = 16,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!,
                RoleId = 1,
                FormId = 14,
                PermissionId = 1,
            };

            var RoleFormPermissionGrade = new RoleFormPermission()
            {
                Id = 17,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!,
                RoleId = 1,
                FormId = 15,
                PermissionId = 1,
            };

            var RoleFormPermissionLineThematic = new RoleFormPermission()
            {
                Id = 18,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!,
                RoleId = 1,
                FormId = 16,
                PermissionId = 1,
            };

            var RoleFormPermissionPopulationGrade = new RoleFormPermission()
            {
                Id = 19,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!,
                RoleId = 1,
                FormId = 17,
                PermissionId = 1,
            };

            var RoleFormPermissionState = new RoleFormPermission()
            {
                Id = 20,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!,
                RoleId = 1,
                FormId = 18,
                PermissionId = 1,
            };

            var RoleFormPermissionExperi = new RoleFormPermission()
            {
                Id = 21,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!,
                RoleId = 1,
                FormId = 19,
                PermissionId = 1,
            };


            // Roles - Forms - Permissions (PROFESOR: solo Inicio y Experiencia)
            var RoleFormPermissionTeacherInicio = new RoleFormPermission()
            {
                Id = 11,
                RoleId = 2,
                FormId = 1, // Inicio
                PermissionId = 2, // Solo lectura
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var RoleFormPermissionTeacherExperiencia = new RoleFormPermission()
            {
                Id = 12,
                RoleId = 2,
                FormId = 2, // Experiencia
                PermissionId = 2, // Solo lectura
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };

          


            // Roles - Forms - Permissions (Admin: solo Inicio y Experiencia)



            modelBuilder.Entity<RoleFormPermission>().HasData(
      RoleFormPermissionInicio,
      RoleFormPermissionExperiencia,
      RoleFormPermissionEvaluacion,
      RoleFormPermissionRoles,
      RoleFormPermissionUsers,
      RoleFormPermissionPersons,
      RoleFormPermissionSeguimiento,
      RoleFormPermissionPermissions,
      RoleFormPermissionForms,
      RoleFormPermissionModules,
      RoleFormPermissionTeacherInicio,
      RoleFormPermissionTeacherExperiencia,
      RoleFormPermissionUsersRol,
      RoleFormPermissionFormModule,
      RoleFormPermissionRolFormPermission,
      RoleFormPermissionCriteria,
      RoleFormPermissionGrade,
      RoleFormPermissionLineThematic,
      RoleFormPermissionPopulationGrade,
      RoleFormPermissionState,
      RoleFormPermissionExperi
  );

        }
    }
}