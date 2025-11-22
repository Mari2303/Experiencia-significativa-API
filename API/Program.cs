using API;
using Entity.Context;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleBase;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;
using Repository.Implementations.ModuleBaseRepository;
using Repository.Implementations.ModuleOperationRepository;
using Repository.Interfaces.IModuleBaseRepository;
using Repository.Interfaces.IModuleOperationRepository;
using Service.Implementations.ModuleSegurityService;
using Service.Interfaces.IModuleSegurityService;
using System.Text.Json.Serialization;
using Utilities.CreatedPdf.Service;
using Utilities.Email.Implement;
using Utilities.Email.Interfaces;
using Utilities.JwtAuthentication;




var builder = WebApplication.CreateBuilder(args);


// SQL Server
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// PostgreSQL (habilítalo si lo necesitas)
builder.Services.AddDbContext<ApplicationContextPostgres>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

// MySQL (deshabilitado por ahora)
/*
builder.Services.AddDbContext<ApplicationContextMySQL>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MysqlConnetion"),
        new MySqlServerVersion(new Version(8, 0, 36))
    ));
*/


builder.Services.AddControllers().AddJsonOptions(options =>
{
    // Evitar referencias cíclicas
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<SupabaseStorageService>();
builder.Services.AddScoped<SubeBaseExperienceStorage>();


AuthenticationExtensions.CustomSwagger(builder.Services);

ServiceExtensions.AddCustomServices(builder.Services);

QuestPDF.Settings.License = LicenseType.Community;



// Configurar JwtAuthentication como Singleton
builder.Services.AddSingleton<IJwtAuthentication, JwtAuthentication>(provider =>
{
    var key = builder.Configuration.GetSection("JwtConfig")["Key"];
    return new JwtAuthentication(key);
});

// Configurar servicio de autenticación
builder.Services.AddSingleton<IJwtAuthenticationService, JwtAuthenticationService>();



// Añadir autenticación personalizada
AuthenticationExtensions.AddCustomAuthentication(builder.Services, builder.Configuration);
MapperExtension.ConfigureAutoMapper(builder.Services);





//  SERVICIO DE EMAIL

builder.Services.AddTransient<Utilities.Email.Interfaces.IEmailService, Utilities.Email.Implements.EmailService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBrevoEmailService, BrevoEmailService>();


builder.Services.AddScoped<AccountNotificationService>();
builder.Services.AddScoped<IEmailEvaluationBrevoService, EmailEvaluationBrevoService>();


builder.Services.Configure<PdfSettingsRequest>(builder.Configuration.GetSection("PdfSettings"));

builder.Services.AddSignalR();

builder.Services.AddScoped<IExperienceEditPermissionRepository, ExperienceEditPermissionRepository>();





// CONFIGURACIÓN DE CORS (permite acceso desde frontend)

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// CONSTRUCCIÓN DE LA APLICACIÓN

var app = builder.Build();


//  MIGRACIONES AUTOMÁTICAS (opcional)

using (var scope = app.Services.CreateScope())
{
    var sqlServerContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    sqlServerContext.Database.Migrate();

    // Si deseas aplicar también las migraciones de otros motores, descomenta:
    
 //   var postgresContext = scope.ServiceProvider.GetRequiredService<ApplicationContextPostgres>();
   // postgresContext.Database.Migrate();

//    var mySqlContext = scope.ServiceProvider.GetRequiredService<ApplicationContextMySQL>();
  //  mySqlContext.Database.Migrate();
    
}


//  CONFIGURACIÓN DEL PIPELINE HTTP


    app.UseSwagger();
    app.UseSwaggerUI();


// CORS global
app.UseCors("AllowAll");

// HTTPS Redirection
app.UseHttpsRedirection();

// Autenticación y Autorización
app.UseAuthentication();
app.UseAuthorization();

// Mapear controladores
app.MapControllers();
app.MapHub<NotificationHub>("/hubs/notifications");
// Ejecutar aplicación
app.Run();
