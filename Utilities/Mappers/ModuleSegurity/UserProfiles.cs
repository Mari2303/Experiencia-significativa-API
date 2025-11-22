using AutoMapper;
using Entity.Dtos.ModuleSegurity;
using Entity.Models;
using Entity.Requests.ModuleSegurity;
using Utilities.JwtAuthentication;

namespace Utilities.Mappers.ModuleSegurity
{
    /// <summary>
    /// Define un mapeador para usuarios que realiza la conversión entre entidades y objetos de transferencia de datos (DTOs).
    /// Esta clase configura los mapeos para el modelo User y sus correspondientes DTOs.
    /// </summary>
    public class UserProfiles : Profile
    {
        private readonly IJwtAuthentication _jwtAuthentication;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="UserProfiles"/> con el servicio de autenticación JWT para cifrado de contraseñas.
        /// </summary>
        /// <param name="jwtAuthentication">El servicio de autenticación JWT utilizado para cifrar las contraseñas mediante MD5.</param>
        public UserProfiles(IJwtAuthentication jwtAuthentication) : base()
        {
            _jwtAuthentication = jwtAuthentication;

            // Mapeo de UserDTO a User con cifrado de contraseña
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => _jwtAuthentication.EncryptMD5(src.Password)));

            // Mapeo de User a UserDTO
            CreateMap<User, UserDTO>()
            .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.Person.Email))
            .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src =>
                src.Person.FirstName + " " + src.Person.FirstLastName));

            // Mapeo de UserRequest a User con cifrado de contraseña
            CreateMap<UserRequest, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => _jwtAuthentication.EncryptMD5(src.Password)));

            // Mapeo de User a UserRequest
            CreateMap<User, UserRequest>();
        }
    }
}
