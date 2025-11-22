using Entity.Dtos.ModuleSegurity;
using Entity.Models;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces.IModuleSegurityRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.IModuleSegurityService;
using System;
using Utilities.Email.Interfaces;

namespace Service.Implementations.ModuleSegurityService
{

    public class UserService : BaseModelService<User, UserDTO, UserRequest>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IEmailService _emailService;
        private readonly IPersonRepository _personRepository;
        private readonly AccountNotificationService _accountNotificationService;


        public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IEmailService emailService, AccountNotificationService accountNotification, IPersonRepository personRepository) : base(userRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _emailService = emailService;
            _accountNotificationService = accountNotification;
            _personRepository = personRepository;
        }


        public async Task<UserRequest> GetByName(string name)
        {
            return await _userRepository.GetByName(name);
        }




        private string EncryptMD5(string input)
        {
            using var md5 = System.Security.Cryptography.MD5.Create();
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes);
        }




        public async Task<List<MenuRequest>> GetMenuAsync(int userId)
        {
            // Obtenemos el menú directo desde el UserRepository
            var menuItems = await _userRepository.GetMenuAsync(userId);

            // No necesitamos agrupar, solo devolvemos la lista tal cual
            return menuItems;
        }







        public async Task SendRecoveryCodeAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                throw new Exception("Usuario no encontrado");

            if (user.Person == null || string.IsNullOrEmpty(user.Person.Email))
                throw new Exception("Usuario no tiene correo registrado");

            // Generar código de 6 dígitos
            var code = new Random().Next(100000, 999999).ToString();

            // Guardar código y expiración en User
            user.RecoveryCode = code;
            user.RecoveryCodeExpiration = DateTime.UtcNow.AddMinutes(10);

            await _userRepository.UpdateAsync(user);

            // Enviar correo usando tu EmailService
            await _emailService.SendExperiencesEmail(user.Person.Email, code);
        }





        public async Task ResetPasswordAsync(string email, string code, string newPassword)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                throw new Exception("Usuario no encontrado");

            // Validar código y expiración
            if (user.RecoveryCode != code || user.RecoveryCodeExpiration == null || user.RecoveryCodeExpiration < DateTime.UtcNow)
                throw new Exception("Código inválido o expirado");



            // Encriptar la contraseña con MD5
            user.Password = EncryptMD5(newPassword);

            // Limpiar código de recuperación
            user.RecoveryCode = null;
            user.RecoveryCodeExpiration = null;

            await _userRepository.UpdateAsync(user);


        }






        public async Task<UserDTO> ActivateAccountAsync(int userId)
        {
            //  Obtener el usuario
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("Usuario no encontrado.");

            //  Validar si ya está activo
            if (user.State)
                throw new Exception("La cuenta ya se encuentra activada.");

            //  Obtener la persona asociada (porque el email está allí)
            var person = await _personRepository.GetById(user.PersonId);
            if (person == null)
                throw new Exception("No se encontró la persona asociada al usuario.");

            // 4 Activar usuario
            await _userRepository.Restore(userId);

            // Enviar correo con la plantilla Brevo
            var fullName = $"{person.FirstName} {person.FirstLastName}";
            await _accountNotificationService.NotifyAccountActivatedAsync(person.Email, fullName);

            // Devolver respuesta limpia
            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                State = user.State,
                Code = user.Code
            };
        }


    }

}



