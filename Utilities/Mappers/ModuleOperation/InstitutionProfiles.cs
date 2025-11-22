using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityDataRequest;
using Entity.Requests.ModuleOperation;

namespace Utilities.Mappers.ModuleOperation
{
    public class InstitutionProfiles : Profile
    {
        public InstitutionProfiles() : base()
        {
            // Mapeos principales
            CreateMap<InstitutionDTO, Institution>().ReverseMap();
            CreateMap<InstitutionRequest, Institution>().ReverseMap();

            // Mapeo detallado entre entidad y request (con colecciones)
            CreateMap<Institution, InstitutionRequest>()
                .ForMember(dest => dest.Departamentes, opt => opt.MapFrom(src => src.Departaments))
                .ForMember(dest => dest.Municipalities, opt => opt.MapFrom(src => src.Municipalitis))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresss))
                .ForMember(dest => dest.EEZones, opt => opt.MapFrom(src => src.EEZones))
                .ForMember(dest => dest.Communes, opt => opt.MapFrom(src => src.Communes))
                .ReverseMap();

            // Mapeo adicional para visualización: Institution → InstitutionInfoRequest
            CreateMap<Institution, InstitutionInfoRequest>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CodeDane, opt => opt.MapFrom(src => src.CodeDane))
                // Si el departamento o municipio vienen de entidades relacionadas:
                .ForMember(dest => dest.Departamentes, opt => opt.MapFrom(src => src.Departaments))
                .ForMember(dest => dest.Municipalities, opt => opt.MapFrom(src => src.Municipalitis))
                
                .ReverseMap();
        }
    }
}

