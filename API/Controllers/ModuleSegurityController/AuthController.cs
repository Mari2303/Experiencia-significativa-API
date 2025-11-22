using AutoMapper;
using Entity.Models;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleBase;
using Entity.Requests.ModuleSegurity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces.IModuleSegurityService;

namespace API.Controllers.ModuleSegurityController
{
    /// <summary>
    /// Controlador encargado de la autenticación de usuarios.
    /// Maneja login, cambio de contraseña y renovación de tokens JWT.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService; // Servicio de autenticación
        private readonly IMapper _mapper; // Mapper para convertir entre entidades y DTOs

        /// <summary>
        /// Constructor del controlador, inyecta el servicio de autenticación y AutoMapper.
        /// </summary>
        /// <param name="authService">Servicio de autenticación.</param>
        /// <param name="mapper">Servicio de AutoMapper.</param>
        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        /// <summary>
        /// Endpoint de login.
        /// Permite a un usuario autenticarse y recibir un token JWT.
        /// </summary>
        /// <param name="auth">DTO con Username y Password.</param>
        /// <returns>Token JWT y datos del usuario si el login es exitoso.</returns>
        [AllowAnonymous] // Permite acceso sin token
        [HttpPost("Login")]
        public async Task<ActionResult> LoginAsync([FromBody] AuthenticationRequest auth)
        {
            try
            {
                // Llamada al servicio de autenticación
                UserLoginResponseRequest data = await _authService.LoginAsync(auth.Username, auth.Password);

                // Retorna un objeto ApiResponseRequest con los datos y mensaje
                return Ok(new ApiResponseRequest<UserLoginResponseRequest>(data, true, "Session started successfully"));
            }
            catch (Exception ex)
            {
                // Manejo de errores y respuesta de error
                var response = new ApiResponseRequest<UserLoginResponseRequest>(null!, false, ex.Message.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }


        /// <summary>
        /// Endpoint para cambiar la contraseña de un usuario.
        /// Requiere que el usuario esté autenticado.
        /// </summary>
        /// <param name="dto">DTO con la contraseña antigua y nueva.</param>
        /// <returns>Resultado de la operación.</returns>
        [Authorize] // Requiere token válido
        [HttpPut("UpdatePassword")]
        public async Task<ActionResult> UpdatePassword([FromBody] ChangePasswordRequest dto)
        {
            try
            {
                // Llama al servicio para cambiar la contraseña
                await _authService.ChangePasswordAsync(dto);

                var response = new ApiResponseRequest<User>(null!, true, "Password updated successfully");
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                var response = new ApiResponseRequest<IEnumerable<User>>(null!, false, ex.Message.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Endpoint para renovar el token JWT.
        /// Permite que un usuario obtenga un nuevo token antes de que expire.
        /// </summary>
        /// <returns>Nuevo token JWT.</returns>
        [Authorize]
        [HttpPut("RenewToken")]
        public async Task<ActionResult> RenewToken()
        {
            try
            {
                // Obtener el header Authorization
                var authHeader = HttpContext.Request.Headers["Authorization"].ToString();

                if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
                {
                    return Unauthorized(new ApiResponseRequest<string>(null!, false, "Authorization header is missing or invalid"));
                }

                // Extraer el token quitando "Bearer "
                var token = authHeader.Substring("Bearer ".Length).Trim();

                // Pasar el token al servicio para renovarlo
                var newToken = await _authService.RenewTokenAsync(token);

                return Ok(new ApiResponseRequest<RenewTokenRequest>(newToken, true, "Token renewed successfully"));
            }
            catch (Exception ex)
            {
                var response = new ApiResponseRequest<RenewTokenRequest>(null!, false, $"Failed to renew token: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
