using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity.MigrationsSqlServer
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Criteria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criteria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    CodeDane = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailInstitucional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameRector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caracteristic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TerritorialEntity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestsKnow = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineThematics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineThematics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PasswordRecoveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordRecoveries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeDane = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailInstitutional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PopulationGrade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopulationGrade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StateExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateExperiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Communes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Communes_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departaments_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EEZones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EEZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EEZones_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipalities_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormModules_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecoveryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecoveryCodeExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleFormPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleFormPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleFormPermissions_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleFormPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleFormPermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameExperiences = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThematicLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Developmenttime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recognition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Socialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlPdf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateExperienceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InstitucionId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Institutions_InstitucionId",
                        column: x => x.InstitucionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experiences_StateExperiences_StateExperienceId",
                        column: x => x.StateExperienceId,
                        principalTable: "StateExperiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experiences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Development",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrossCuttingProject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PedagogicalStrategies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coverage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CovidPandemic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Development", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Development_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlPdf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlPdfExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeEvaluation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccompanimentRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvaluationResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlEvaPdf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    StateExperienceId = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluations_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluations_StateExperiences_StateExperienceId",
                        column: x => x.StateExperienceId,
                        principalTable: "StateExperiences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Evaluations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceEditPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceEditPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperienceEditPermissions_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperienceEditPermissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperienceGrades_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperienceGrades_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceLineThematics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    LineThematicId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceLineThematics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperienceLineThematics_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperienceLineThematics_LineThematics_LineThematicId",
                        column: x => x.LineThematicId,
                        principalTable: "LineThematics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExperiencePopulation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    PopulationGradeId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperiencePopulation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperiencePopulation_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperiencePopulation_PopulationGrade_PopulationGradeId",
                        column: x => x.PopulationGradeId,
                        principalTable: "PopulationGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StateExperienceId = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryExperiences_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryExperiences_StateExperiences_StateExperienceId",
                        column: x => x.StateExperienceId,
                        principalTable: "StateExperiences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoryExperiences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameLeaders = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaders_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Objectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionProblem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectiveExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnfoqueExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Methodologias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pmi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nnaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InnovationExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objectives_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationCriterias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    EvaluationId = table.Column<int>(type: "int", nullable: false),
                    CriteriaId = table.Column<int>(type: "int", nullable: false),
                    DescriptionContribution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationCriterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationCriterias_Criteria_CriteriaId",
                        column: x => x.CriteriaId,
                        principalTable: "Criteria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluationCriterias_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monitorings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonitoringEvaluation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sustainability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tranfer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectiveId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitorings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monitorings_Objectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "Objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupportInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaphoricalPhrase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Testimony = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FollowEvaluation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectiveId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportInformations_Objectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "Objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Criteria",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Name", "State" },
                values: new object[,]
                {
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
========
<<<<<<<< HEAD:Entity/MigrationsSqlServer/20251124231825_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                    { 1, "01", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Pertinencia", true },
                    { 2, "02", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Fundamentación", true },
                    { 3, "03", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Innovación", true },
                    { 4, "04", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Resultados", true },
                    { 5, "05", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Empoderamiento", true },
                    { 6, "06", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Seguimiento y valoración", true },
                    { 7, "07", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Transformación", true },
                    { 8, "08", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Sostenibilidad", true },
                    { 9, "09", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Transferencia", true }
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
========
========
                    { 1, "01", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Pertinencia", true },
                    { 2, "02", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Fundamentación", true },
                    { 3, "03", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Innovación", true },
                    { 4, "04", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Resultados", true },
                    { 5, "05", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Empoderamiento", true },
                    { 6, "06", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Seguimiento y valoración", true },
                    { 7, "07", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Transformación", true },
                    { 8, "08", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Sostenibilidad", true },
                    { 9, "09", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Transferencia", true }
>>>>>>>> 0a32592 (Commit Correction DeveloTime):Entity/MigrationsSqlServer/20251126225001_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Icon", "Name", "Order", "Path", "State" },
                values: new object[,]
                {
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
========
<<<<<<<< HEAD:Entity/MigrationsSqlServer/20251124231825_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                    { 1, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Vista principal del sistema.", "fa-solid fa-house", "Inicio", 1, "dashboard", true },
                    { 2, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Gestión de experiencias significativas.", "fa-solid fa-star", "Experiencia", 2, "experiences", true },
                    { 3, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Gestión de evaluaciones.", "fa-solid fa-clipboard-check", "Evaluación", 3, "evaluation", true },
                    { 4, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Gestión de roles del sistema.", "fa-solid fa-users-gear", "Roles", 5, "roles", true },
                    { 5, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Gestión de usuarios.", "fa-solid fa-users", "Usuarios", 6, "users", true },
                    { 6, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Gestión de personas.", "fa-solid fa-user", "Personas", 7, "persons", true },
                    { 7, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Formulario de seguimiento.", "fa-solid fa-building-user", "Seguimiento", 4, "tracking", true },
                    { 8, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Allows you to assign specific permissions to users and roles, controlling access to functions, forms, and modules according to the system's needs and security policies.", "fa-solid fa-user-lock", "Permisos", 8, "permissions", true },
                    { 9, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Manages system modules, allowing users to define, modify, and assign modules available to them based on established roles and permissions.", "fa-solid fa-window-maximize", "Modulos", 9, "modules", true },
                    { 10, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Manages the forms available in the system, allowing the creation, modification, and deletion of forms associated with different functionalities and modules.", "fa-solid fa-window-restore", "Formularios", 10, "forms", true },
                    { 11, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Gestiona los roles de usuario dentro del sistema, permitiendo la asignación, modificación y eliminación de permisos según las responsabilidades y niveles de acceso de cada usuario.", "fa-solid fa-window-restore", "Asignación de Roles", 11, "usersRol", true },
                    { 12, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Gestiona la relación entre formularios y módulos del sistema, permitiendo organizar, vincular y estructurar los formularios dentro de las diferentes secciones o áreas funcionales.", "fa-solid fa-window-restore", "Asignación de Formularios", 12, "formModule", true },
                    { 13, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Gestiona la relación entre roles y formularios del sistema, permitiendo definir, organizar y controlar los permisos de acceso y acciones que cada rol puede realizar sobre los diferentes formularios.", "fa-solid fa-window-restore", "Asignación por permisos", 13, "rolFormPermission", true },
                    { 14, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Formulario de Criterios", "fa-solid fa-window-restore", "Asignación de Criterios", 14, "criteria", true },
                    { 15, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Formulario de Grados", "fa-solid fa-window-restore", "Asignación de Grados", 15, "grade", true },
                    { 16, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Formulario de Líenas Temáticas", "fa-solid fa-window-restore", "Asignación de Líneas Temáticas", 16, "lineThematic", true },
                    { 17, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Formulario de grupo poblacional", "fa-solid fa-window-restore", "Asignación de Grupo Poblacional", 17, "populationGrade", true },
                    { 18, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Formulario del estado", "fa-solid fa-window-restore", "Asignación de Estado", 18, "state", true },
                    { 19, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "permite hacer el seguimiento de edicion de los formularios", "fa-solid fa-window-restore", "gestion experiencia", 19, "experiensGestion", true }
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
========
========
                    { 1, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Vista principal del sistema.", "fa-solid fa-house", "Inicio", 1, "dashboard", true },
                    { 2, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Gestión de experiencias significativas.", "fa-solid fa-star", "Experiencia", 2, "experiences", true },
                    { 3, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Gestión de evaluaciones.", "fa-solid fa-clipboard-check", "Evaluación", 3, "evaluation", true },
                    { 4, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Gestión de roles del sistema.", "fa-solid fa-users-gear", "Roles", 5, "roles", true },
                    { 5, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Gestión de usuarios.", "fa-solid fa-users", "Usuarios", 6, "users", true },
                    { 6, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Gestión de personas.", "fa-solid fa-user", "Personas", 7, "persons", true },
                    { 7, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Formulario de seguimiento.", "fa-solid fa-building-user", "Seguimiento", 4, "tracking", true },
                    { 8, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Allows you to assign specific permissions to users and roles, controlling access to functions, forms, and modules according to the system's needs and security policies.", "fa-solid fa-user-lock", "Permisos", 8, "permissions", true },
                    { 9, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Manages system modules, allowing users to define, modify, and assign modules available to them based on established roles and permissions.", "fa-solid fa-window-maximize", "Modulos", 9, "modules", true },
                    { 10, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Manages the forms available in the system, allowing the creation, modification, and deletion of forms associated with different functionalities and modules.", "fa-solid fa-window-restore", "Formularios", 10, "forms", true },
                    { 11, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Gestiona los roles de usuario dentro del sistema, permitiendo la asignación, modificación y eliminación de permisos según las responsabilidades y niveles de acceso de cada usuario.", "fa-solid fa-window-restore", "Asignación de Roles", 11, "usersRol", true },
                    { 12, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Gestiona la relación entre formularios y módulos del sistema, permitiendo organizar, vincular y estructurar los formularios dentro de las diferentes secciones o áreas funcionales.", "fa-solid fa-window-restore", "Asignación de Formularios", 12, "formModule", true },
                    { 13, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Gestiona la relación entre roles y formularios del sistema, permitiendo definir, organizar y controlar los permisos de acceso y acciones que cada rol puede realizar sobre los diferentes formularios.", "fa-solid fa-window-restore", "Asignación por permisos", 13, "rolFormPermission", true },
                    { 14, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Formulario de Criterios", "fa-solid fa-window-restore", "Asignación de Criterios", 14, "criteria", true },
                    { 15, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Formulario de Grados", "fa-solid fa-window-restore", "Asignación de Grados", 15, "grade", true },
                    { 16, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Formulario de Líenas Temáticas", "fa-solid fa-window-restore", "Asignación de Líneas Temáticas", 16, "lineThematic", true },
                    { 17, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Formulario de grupo poblacional", "fa-solid fa-window-restore", "Asignación de Grupo Poblacional", 17, "populationGrade", true },
                    { 18, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Formulario del estado", "fa-solid fa-window-restore", "Asignación de Estado", 18, "state", true },
                    { 19, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "permite hacer el seguimiento de edicion de los formularios", "fa-solid fa-window-restore", "gestion experiencia", 19, "experiensGestion", true }
>>>>>>>> 0a32592 (Commit Correction DeveloTime):Entity/MigrationsSqlServer/20251126225001_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Description", "Name", "State" },
                values: new object[,]
                {
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
========
<<<<<<<< HEAD:Entity/MigrationsSqlServer/20251124231825_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                    { 1, "01", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "", "Primaria Infancia (Jardin-transicion)", true },
                    { 2, "02", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "", "Primaria", true },
                    { 3, "03", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "", "Basic", true },
                    { 4, "04", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "", "Media", true },
                    { 5, "05", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "", "CLEI", true },
                    { 6, "06", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "", "Todas las anteriores", true }
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
========
========
                    { 1, "01", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "", "Primaria Infancia (Jardin-transicion)", true },
                    { 2, "02", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "", "Primaria", true },
                    { 3, "03", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "", "Basic", true },
                    { 4, "04", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "", "Media", true },
                    { 5, "05", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "", "CLEI", true },
                    { 6, "06", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "", "Todas las anteriores", true }
>>>>>>>> 0a32592 (Commit Correction DeveloTime):Entity/MigrationsSqlServer/20251126225001_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                });

            migrationBuilder.InsertData(
                table: "LineThematics",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Name", "State" },
                values: new object[,]
                {
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
========
<<<<<<<< HEAD:Entity/MigrationsSqlServer/20251124231825_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                    { 1, "01", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Ciencia y Tecnología", true },
                    { 2, "02", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Educación Ambiental", true },
                    { 3, "03", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Interculturalidad Bilingüismo", true },
                    { 4, "04", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Arte, Cultura y Patrimonio", true },
                    { 5, "05", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Habilidades Comunicativas", true },
                    { 6, "06", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Academica Curricular", true },
                    { 7, "07", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Inclusion Diversidad", true },
                    { 8, "08", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Convivencia Escolar (Ciencias Sociales y Políticas)", true },
                    { 9, "09", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Danza, Deporte y Recreación", true }
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
========
========
                    { 1, "01", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Ciencia y Tecnología", true },
                    { 2, "02", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Educación Ambiental", true },
                    { 3, "03", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Interculturalidad Bilingüismo", true },
                    { 4, "04", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Arte, Cultura y Patrimonio", true },
                    { 5, "05", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Habilidades Comunicativas", true },
                    { 6, "06", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Academica Curricular", true },
                    { 7, "07", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Inclusion Diversidad", true },
                    { 8, "08", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Convivencia Escolar (Ciencias Sociales y Políticas)", true },
                    { 9, "09", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Danza, Deporte y Recreación", true }
>>>>>>>> 0a32592 (Commit Correction DeveloTime):Entity/MigrationsSqlServer/20251126225001_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Name", "State" },
                values: new object[,]
                {
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
                    { 1, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "El módulo de seguridad gestiona autenticación, roles, permisos y acceso a los formularios del sistema.", "Security", true },
                    { 2, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "El módulo operativo gestiona los formularios funcionales principales del sistema.", "Operational", true },
                    { 3, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "El módulo de parametrización gestiona los formularios que controlan el comportamiento general del sistema.", "Parametrización", true }
========
<<<<<<<< HEAD:Entity/MigrationsSqlServer/20251124231825_InitialCreate.cs
                    { 1, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "El módulo de seguridad gestiona autenticación, roles, permisos y acceso a los formularios del sistema.", "Security", true },
                    { 2, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "El módulo operativo gestiona los formularios funcionales principales del sistema.", "Operational", true },
                    { 3, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "El módulo de parametrización gestiona los formularios que controlan el comportamiento general del sistema.", "Parametrización", true }
========
                    { 1, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "El módulo de seguridad gestiona autenticación, roles, permisos y acceso a los formularios del sistema.", "Security", true },
                    { 2, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "El módulo operativo gestiona los formularios funcionales principales del sistema.", "Operational", true },
                    { 3, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "El módulo de parametrización gestiona los formularios que controlan el comportamiento general del sistema.", "Parametrización", true }
>>>>>>>> 0a32592 (Commit Correction DeveloTime):Entity/MigrationsSqlServer/20251126225001_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Description", "Name", "State" },
                values: new object[,]
                {
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
                    { 1, "0001", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Allows the user to query, update, and delete records within the system, granting full access to the management of associated data.", "Reading and writing", true },
                    { 2, "0002", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Allows the user to only view records within the system, without permission to perform updates or deletions.", "Reading only", true }
========
<<<<<<<< HEAD:Entity/MigrationsSqlServer/20251124231825_InitialCreate.cs
                    { 1, "0001", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Allows the user to query, update, and delete records within the system, granting full access to the management of associated data.", "Reading and writing", true },
                    { 2, "0002", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Allows the user to only view records within the system, without permission to perform updates or deletions.", "Reading only", true }
========
                    { 1, "0001", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Allows the user to query, update, and delete records within the system, granting full access to the management of associated data.", "Reading and writing", true },
                    { 2, "0002", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Allows the user to only view records within the system, without permission to perform updates or deletions.", "Reading only", true }
>>>>>>>> 0a32592 (Commit Correction DeveloTime):Entity/MigrationsSqlServer/20251126225001_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "CodeDane", "CreatedAt", "DeletedAt", "DocumentType", "Email", "EmailInstitutional", "FirstLastName", "FirstName", "IdentificationNumber", "MiddleName", "Phone", "SecondLastName", "State" },
                values: new object[,]
                {
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
                    { 1, "441001004839", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 1, "mariaalejan1080@gmail.com", "mariaa_marinh@soy.sena.com", "MARIN", "MARIA", "1000000000", "ALEJANDRA", 3243652328L, "HENRIQUEZ", true },
                    { 2, "441001004840", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 1, "catalina2005cometa@gmail.com", "catalina@soy.sena.com", "PEREZ", "JUAN", "2000000000", "CARLOS", 3123456789L, "GOMEZ", true }
========
<<<<<<<< HEAD:Entity/MigrationsSqlServer/20251124231825_InitialCreate.cs
                    { 1, "441001004839", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 1, "mariaalejan1080@gmail.com", "mariaa_marinh@soy.sena.com", "MARIN", "MARIA", "1000000000", "ALEJANDRA", 3243652328L, "HENRIQUEZ", true },
                    { 2, "441001004840", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 1, "catalina2005cometa@gmail.com", "catalina@soy.sena.com", "PEREZ", "JUAN", "2000000000", "CARLOS", 3123456789L, "GOMEZ", true }
========
                    { 1, "441001004839", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 1, "mariaalejan1080@gmail.com", "mariaa_marinh@soy.sena.com", "MARIN", "MARIA", "1000000000", "ALEJANDRA", 3243652328L, "HENRIQUEZ", true },
                    { 2, "441001004840", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 1, "catalina2005cometa@gmail.com", "catalina@soy.sena.com", "PEREZ", "JUAN", "2000000000", "CARLOS", 3123456789L, "GOMEZ", true }
>>>>>>>> 0a32592 (Commit Correction DeveloTime):Entity/MigrationsSqlServer/20251126225001_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                });

            migrationBuilder.InsertData(
                table: "PopulationGrade",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Name", "State" },
                values: new object[,]
                {
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
========
<<<<<<<< HEAD:Entity/MigrationsSqlServer/20251124231825_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                    { 1, "01", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Negritudes", true },
                    { 2, "02", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Afrodecendientes", true },
                    { 3, "03", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Palanquero", true },
                    { 4, "04", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Rizal", true },
                    { 5, "05", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Rom/Gitano", true },
                    { 6, "06", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Victima del conficto", true },
                    { 7, "07", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Diacapacidad", true },
                    { 8, "08", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Talentos Excepcionales", true },
                    { 9, "09", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Indigena", true },
                    { 10, "10", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Trastornos Especificos", true },
                    { 11, "11", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Ninguna de las anteriores", true }
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
========
========
                    { 1, "01", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Negritudes", true },
                    { 2, "02", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Afrodecendientes", true },
                    { 3, "03", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Palanquero", true },
                    { 4, "04", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Rizal", true },
                    { 5, "05", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Rom/Gitano", true },
                    { 6, "06", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Victima del conficto", true },
                    { 7, "07", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Diacapacidad", true },
                    { 8, "08", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Talentos Excepcionales", true },
                    { 9, "09", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Indigena", true },
                    { 10, "10", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Trastornos Especificos", true },
                    { 11, "11", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Ninguna de las anteriores", true }
>>>>>>>> 0a32592 (Commit Correction DeveloTime):Entity/MigrationsSqlServer/20251126225001_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Description", "Name", "State" },
                values: new object[,]
                {
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
                    { 1, "01", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "", "SUPERADMIN", true },
                    { 2, "0002", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Rol para profesores", "Profesor", true }
========
<<<<<<<< HEAD:Entity/MigrationsSqlServer/20251124231825_InitialCreate.cs
                    { 1, "01", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "", "SUPERADMIN", true },
                    { 2, "0002", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Rol para profesores", "Profesor", true }
========
                    { 1, "01", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "", "SUPERADMIN", true },
                    { 2, "0002", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Rol para profesores", "Profesor", true }
>>>>>>>> 0a32592 (Commit Correction DeveloTime):Entity/MigrationsSqlServer/20251126225001_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                });

            migrationBuilder.InsertData(
                table: "StateExperiences",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Name", "State" },
                values: new object[,]
                {
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
                    { 1, "01", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Naciente", true },
                    { 2, "02", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Creciente", true },
                    { 3, "03", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Inspiradora", true }
========
<<<<<<<< HEAD:Entity/MigrationsSqlServer/20251124231825_InitialCreate.cs
                    { 1, "01", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Naciente", true },
                    { 2, "02", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Creciente", true },
                    { 3, "03", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "Inspiradora", true }
========
                    { 1, "01", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Naciente", true },
                    { 2, "02", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Creciente", true },
                    { 3, "03", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "Inspiradora", true }
>>>>>>>> 0a32592 (Commit Correction DeveloTime):Entity/MigrationsSqlServer/20251126225001_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                });

            migrationBuilder.InsertData(
                table: "FormModules",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "FormId", "ModuleId", "State" },
                values: new object[,]
                {
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
========
<<<<<<<< HEAD:Entity/MigrationsSqlServer/20251124231825_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                    { 1, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 1, 2, true },
                    { 2, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 2, 2, true },
                    { 3, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 3, 2, true },
                    { 4, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 4, 1, true },
                    { 5, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 5, 1, true },
                    { 6, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 6, 1, true },
                    { 7, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 7, 2, true },
                    { 8, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 8, 1, true },
                    { 9, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 9, 1, true },
                    { 10, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 10, 1, true },
                    { 11, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 11, 1, true },
                    { 12, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 12, 1, true },
                    { 13, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 13, 1, true },
                    { 14, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 14, 3, true },
                    { 15, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 15, 3, true },
                    { 16, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 16, 3, true },
                    { 17, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 17, 3, true },
                    { 18, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 18, 3, true },
                    { 19, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 19, 2, true }
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
========
========
                    { 1, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 1, 2, true },
                    { 2, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 2, 2, true },
                    { 3, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 3, 2, true },
                    { 4, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 4, 1, true },
                    { 5, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 5, 1, true },
                    { 6, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 6, 1, true },
                    { 7, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 7, 2, true },
                    { 8, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 8, 1, true },
                    { 9, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 9, 1, true },
                    { 10, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 10, 1, true },
                    { 11, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 11, 1, true },
                    { 12, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 12, 1, true },
                    { 13, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 13, 1, true },
                    { 14, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 14, 3, true },
                    { 15, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 15, 3, true },
                    { 16, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 16, 3, true },
                    { 17, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 17, 3, true },
                    { 18, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 18, 3, true },
                    { 19, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 19, 2, true }
>>>>>>>> 0a32592 (Commit Correction DeveloTime):Entity/MigrationsSqlServer/20251126225001_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                });

            migrationBuilder.InsertData(
                table: "RoleFormPermissions",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "FormId", "PermissionId", "RoleId", "State" },
                values: new object[,]
                {
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
========
<<<<<<<< HEAD:Entity/MigrationsSqlServer/20251124231825_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                    { 1, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 1, 1, 1, true },
                    { 2, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 2, 1, 1, true },
                    { 3, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 3, 1, 1, true },
                    { 4, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 4, 1, 1, true },
                    { 5, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 5, 1, 1, true },
                    { 6, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 6, 1, 1, true },
                    { 7, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 7, 1, 1, true },
                    { 8, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 8, 1, 1, true },
                    { 9, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 9, 1, 1, true },
                    { 10, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 10, 1, 1, true },
                    { 11, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 1, 2, 2, true },
                    { 12, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 2, 2, 2, true },
                    { 13, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 11, 1, 1, true },
                    { 14, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 12, 1, 1, true },
                    { 15, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 13, 1, 1, true },
                    { 16, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 14, 1, 1, true },
                    { 17, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 15, 1, 1, true },
                    { 18, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 16, 1, 1, true },
                    { 19, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 17, 1, 1, true },
                    { 20, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 18, 1, 1, true },
                    { 21, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 19, 1, 1, true },
                    { 22, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 19, 2, 2, true }
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
========
========
                    { 1, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 1, 1, 1, true },
                    { 2, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 2, 1, 1, true },
                    { 3, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 3, 1, 1, true },
                    { 4, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 4, 1, 1, true },
                    { 5, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 5, 1, 1, true },
                    { 6, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 6, 1, 1, true },
                    { 7, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 7, 1, 1, true },
                    { 8, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 8, 1, 1, true },
                    { 9, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 9, 1, 1, true },
                    { 10, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 10, 1, 1, true },
                    { 11, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 1, 2, 2, true },
                    { 12, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 2, 2, 2, true },
                    { 13, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 11, 1, 1, true },
                    { 14, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 12, 1, 1, true },
                    { 15, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 13, 1, 1, true },
                    { 16, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 14, 1, 1, true },
                    { 17, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 15, 1, 1, true },
                    { 18, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 16, 1, 1, true },
                    { 19, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 17, 1, 1, true },
                    { 20, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 18, 1, 1, true },
                    { 21, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 19, 1, 1, true },
                    { 22, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 19, 2, 2, true }
>>>>>>>> 0a32592 (Commit Correction DeveloTime):Entity/MigrationsSqlServer/20251126225001_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Password", "PersonId", "RecoveryCode", "RecoveryCodeExpiration", "State", "Username" },
                values: new object[,]
                {
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
                    { 1, "0001", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "202CB962AC59075B964B07152D234B70", 1, null, null, true, "mariaalejan1080@gmail.com" },
                    { 2, "0002", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "202CB962AC59075B964B07152D234B70", 2, null, null, true, "juan.perez@correo.com" }
========
<<<<<<<< HEAD:Entity/MigrationsSqlServer/20251124231825_InitialCreate.cs
                    { 1, "0001", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "202CB962AC59075B964B07152D234B70", 1, null, null, true, "mariaalejan1080@gmail.com" },
                    { 2, "0002", new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, "202CB962AC59075B964B07152D234B70", 2, null, null, true, "juan.perez@correo.com" }
========
                    { 1, "0001", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "202CB962AC59075B964B07152D234B70", 1, null, null, true, "mariaalejan1080@gmail.com" },
                    { 2, "0002", new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, "202CB962AC59075B964B07152D234B70", 2, null, null, true, "juan.perez@correo.com" }
>>>>>>>> 0a32592 (Commit Correction DeveloTime):Entity/MigrationsSqlServer/20251126225001_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "RoleId", "State", "UserId" },
                values: new object[,]
                {
<<<<<<<< HEAD:Entity/MigrationSqlServer/20251124231825_InitialCreate.cs
                    { 1, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 1, true, 1 },
                    { 2, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 2, true, 2 }
========
<<<<<<<< HEAD:Entity/MigrationsSqlServer/20251124231825_InitialCreate.cs
                    { 1, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 1, true, 1 },
                    { 2, new DateTime(2025, 11, 24, 18, 18, 24, 284, DateTimeKind.Utc).AddTicks(2443), null, 2, true, 2 }
========
                    { 1, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 1, true, 1 },
                    { 2, new DateTime(2025, 11, 26, 17, 50, 0, 734, DateTimeKind.Utc).AddTicks(4913), null, 2, true, 2 }
>>>>>>>> 0a32592 (Commit Correction DeveloTime):Entity/MigrationsSqlServer/20251126225001_InitialCreate.cs
>>>>>>>> ac9c60348704fb1fed7cd40219aeb13beb0ef374:Entity/MigrationSql/20251126225001_InitialCreate.cs
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_InstitutionId",
                table: "Addresses",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Communes_InstitutionId",
                table: "Communes",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Departaments_InstitutionId",
                table: "Departaments",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Development_ExperienceId",
                table: "Development",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ExperienceId",
                table: "Documents",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_EEZones_InstitutionId",
                table: "EEZones",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCriterias_CriteriaId",
                table: "EvaluationCriterias",
                column: "CriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCriterias_EvaluationId",
                table: "EvaluationCriterias",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_ExperienceId",
                table: "Evaluations",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_StateExperienceId",
                table: "Evaluations",
                column: "StateExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_UserId",
                table: "Evaluations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceEditPermissions_ExperienceId",
                table: "ExperienceEditPermissions",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceEditPermissions_UserId",
                table: "ExperienceEditPermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceGrades_ExperienceId",
                table: "ExperienceGrades",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceGrades_GradeId",
                table: "ExperienceGrades",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceLineThematics_ExperienceId",
                table: "ExperienceLineThematics",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceLineThematics_LineThematicId",
                table: "ExperienceLineThematics",
                column: "LineThematicId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperiencePopulation_ExperienceId",
                table: "ExperiencePopulation",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperiencePopulation_PopulationGradeId",
                table: "ExperiencePopulation",
                column: "PopulationGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_InstitucionId",
                table: "Experiences",
                column: "InstitucionId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_StateExperienceId",
                table: "Experiences",
                column: "StateExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_UserId",
                table: "Experiences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FormModules_FormId",
                table: "FormModules",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_FormModules_ModuleId",
                table: "FormModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryExperiences_ExperienceId",
                table: "HistoryExperiences",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryExperiences_StateExperienceId",
                table: "HistoryExperiences",
                column: "StateExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryExperiences_UserId",
                table: "HistoryExperiences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaders_ExperienceId",
                table: "Leaders",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Monitorings_ObjectiveId",
                table: "Monitorings",
                column: "ObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipalities_InstitutionId",
                table: "Municipalities",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_ExperienceId",
                table: "Objectives",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFormPermissions_FormId",
                table: "RoleFormPermissions",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFormPermissions_PermissionId",
                table: "RoleFormPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFormPermissions_RoleId",
                table: "RoleFormPermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportInformations_ObjectiveId",
                table: "SupportInformations",
                column: "ObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Communes");

            migrationBuilder.DropTable(
                name: "Departaments");

            migrationBuilder.DropTable(
                name: "Development");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "EEZones");

            migrationBuilder.DropTable(
                name: "EvaluationCriterias");

            migrationBuilder.DropTable(
                name: "ExperienceEditPermissions");

            migrationBuilder.DropTable(
                name: "ExperienceGrades");

            migrationBuilder.DropTable(
                name: "ExperienceLineThematics");

            migrationBuilder.DropTable(
                name: "ExperiencePopulation");

            migrationBuilder.DropTable(
                name: "FormModules");

            migrationBuilder.DropTable(
                name: "HistoryExperiences");

            migrationBuilder.DropTable(
                name: "Leaders");

            migrationBuilder.DropTable(
                name: "Monitorings");

            migrationBuilder.DropTable(
                name: "Municipalities");

            migrationBuilder.DropTable(
                name: "PasswordRecoveries");

            migrationBuilder.DropTable(
                name: "RoleFormPermissions");

            migrationBuilder.DropTable(
                name: "SupportInformations");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Criteria");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "LineThematics");

            migrationBuilder.DropTable(
                name: "PopulationGrade");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Objectives");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Institutions");

            migrationBuilder.DropTable(
                name: "StateExperiences");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
