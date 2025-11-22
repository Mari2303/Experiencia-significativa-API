using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;
using Microsoft.OpenApi.Models;

namespace API
{
    /// <summary>
    /// Extensiones de configuración para la autenticación JWT y Swagger.
    /// </summary>
    public static class AuthenticationExtensions
    {
        /// <summary>
        /// Configura Swagger para usar autenticación JWT mediante el esquema Bearer.
        /// </summary>
        /// <param name="services">El contenedor de servicios de la aplicación.</param>
        public static void CustomSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                // Define la configuración de seguridad para JWT Bearer
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Ingrese solo su token JWT"
                });

                // Agrega la política de seguridad a Swagger
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        /// <summary>
        /// Configura la autenticación JWT para la aplicación.
        /// </summary>
        /// <param name="services">El contenedor de servicios de la aplicación.</param>
        /// <param name="configuration">La configuración de la aplicación para leer la clave secreta.</param>
        public static void AddCustomAuthentication(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:Key"]));
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false, // No valida el emisor
                        ValidateAudience = false, // No valida la audiencia
                        ValidateLifetime = true, // Valida la expiración
                        ValidateIssuerSigningKey = true, // Valida la firma
                        IssuerSigningKey = key
                    };

                    // Manejo de eventos al fallar la autenticación
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            var response = context.Response;
                            response.ContentType = "application/json";
                            response.StatusCode = StatusCodes.Status401Unauthorized;

                            string message;

                            try
                            {
                                throw context.Exception;
                            }
                            catch (SecurityTokenExpiredException)
                            {
                                message = "Token expirado, genera uno nuevo";
                            }
                            catch (SecurityTokenInvalidSignatureException)
                            {
                                message = "Token inválido - falló la verificación de la firma";
                            }
                            catch (Exception)
                            {
                                message = "Autenticación fallida";
                            }

                            var json = JsonSerializer.Serialize(new
                            {
                                error = message
                            });

                            return response.WriteAsync(json);
                        }
                    };
                });
        }
    }
}

