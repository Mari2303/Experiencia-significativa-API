using Entity.Dtos.ModuleSegurity;
using Entity.Enums;
using Entity.Models;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Microsoft.IdentityModel.Tokens.Experimental;
using Repository.Interfaces.IModuleBaseRepository;
using Repository.Interfaces.IModuleSegurityRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.IModuleSegurityService;
using Utilities.Email.Interfaces;
using Utilities.Helper.Implementation;

namespace Service.Implementations.ModuleSegurityService
{

    public class PersonService : BaseModelService<Person, PersonDTO, PersonRequest>, IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;

        public PersonService(IPersonRepository personRepository, IUserRepository userRepository, IRoleRepository roleRepository, IUnitOfWork unitOfWork, IEmailService emailService) : base(personRepository)
        {
            _personRepository = personRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }



        // Método para crear persona desde PersonRequest
        public async Task<UserRegisterResponseRequest> CreatePersonAsync(UserRegisterRequest request)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                PersonValidatorHelper.Validate(request);

                var defaultRole = await _roleRepository.GetByNameRol("Profesor")
                    ?? throw new Exception("El rol 'Profesor' no existe.");

                if (!Enum.TryParse<DocumentType>(request.DocumentType, out var docEnum))
                    throw new Exception("DocumentType inválido");

                var person = new Person
                {
                    DocumentType = (int)docEnum,
                    FirstName = request.FirstName,
                    FirstLastName = request.FirstLastName,
                    SecondLastName = request.SecondLastName,
                    MiddleName = request.MiddleName,
                    IdentificationNumber = request.IdentificationNumber,
                    Email = request.Email,
                    EmailInstitutional = request.EmailInstitutional,
                    Phone = request.Phone,
                    CodeDane = request.CodeDane,
                };

                var savedPerson = await _personRepository.Save(person);

                var user = new User
                {
                    Code = request.Code,
                    Username = request.Username,
                    Password = EncryptMD5(request.Password),
                    PersonId = savedPerson.Id,
                    State = false,
                    CreatedAt = DateTime.UtcNow,
                    UserRoles = new List<UserRole>()
                };

                user.UserRoles.Add(new UserRole
                {
                    RoleId = defaultRole.Id,
                    State = true,
                    CreatedAt = DateTime.UtcNow,
                    User = user
                });

                await _userRepository.AddAsync(user);

                await _unitOfWork.CommitAsync();

                return new UserRegisterResponseRequest
                {
                    PersonId = savedPerson.Id,
                    UserId = user.Id,
                    Username = user.Username
                };
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }













        private string EncryptMD5(string input)
        {
            using var md5 = System.Security.Cryptography.MD5.Create();
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes);
        }
    }
}


