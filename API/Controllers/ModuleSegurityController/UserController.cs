using AutoMapper;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResetPasswordRequest = Entity.Requests.Email.ResetPasswordRequest;
using ForgotPasswordRequest = Entity.Requests.Email.ForgotPasswordRequest;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.IModuleSegurityService;
using API.Controllers.ModuleBaseController;
using Entity.Dtos.ModuleSegurity;
using Entity.Requests.ModuleSegurity;

namespace API.Controllers.ModuleSegurityController
{
    public class UserController : BaseModelController<User, UserDTO, UserRequest>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IBaseModelService<User, UserDTO, UserRequest> baseService, IUserService service, IMapper mapper) : base(baseService, mapper)
        {
            _userService = service;
            _mapper = mapper;
        }


        /// <summary>
        /// Obtener un usuario por nombre
        /// </summary>
        ///     
        [Authorize]
        [HttpGet("{username}")]
        public async Task<IActionResult> GetByName(string username)
        {
            try
            {
                var user = await _userService.GetByName(username);
                if (user == null)
                    return NotFound(new { message = "Usuario no encontrado" });

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }


        [Authorize]
        [HttpGet("{userId}/menu")]
        public async Task<ActionResult<List<MenuRequest>>> GetMenu(int userId)
        {
            var menu = await _userService.GetMenuAsync(userId);
            return Ok(menu);
        }





        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            await _userService.SendRecoveryCodeAsync(request.Email);
            return Ok("Correo de recuperación enviado.");
        }




        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            await _userService.ResetPasswordAsync(request.Email, request.Code, request.NewPassword);
            return Ok("Contraseña actualizada correctamente.");
        }

        /// <summary>
        /// Activa la cuenta de un usuario y envía un correo de notificación.
        /// </summary>
        /// <param name="userId">ID del usuario a activar</param>
        /// <returns>Datos del usuario activado</returns>
         [Authorize]
        [HttpPut("activate/{userId}")]
        public async Task<IActionResult> ActivateAccount(int userId)
        {
            try
            {
                var result = await _userService.ActivateAccountAsync(userId);

                return Ok(new
                {
                    message = "Cuenta activada correctamente. Se ha enviado una notificación al correo asociado.",
                    user = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}
