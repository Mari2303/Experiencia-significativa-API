using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityDetailRequest;
using Entity.Requests.ModuleOperation;

namespace Utilities.Mappers.ModuleOperation
{
    public class EvaluationProfiles : Profile
    {
        public EvaluationProfiles() : base()
        {
            CreateMap<EvaluationDTO, Evaluation>().ReverseMap();
            CreateMap<EvaluationRequest, Evaluation>().ReverseMap();
            CreateMap<Evaluation, EvaluationDetailRequest>()




    .ForMember(dest => dest.CriteriaEvaluations,
               opt => opt.MapFrom(src => src.EvaluationCriterias))
    .ForMember(dest => dest.ExperienceName,
               opt => opt.MapFrom(src => src.Experience.NameExperiences))
    .ForMember(dest => dest.InstitutionName,
               opt => opt.MapFrom(src => src.Experience.Institution != null ? src.Experience.Institution.Name : string.Empty))
    .ForMember(dest => dest.ThematicLineNames,
               opt => opt.MapFrom(src => src.Experience.ExperienceLineThematics
                                           .Where(x => x.LineThematic != null)
                                           .Select(x => x.LineThematic.Name).ToList()));




            CreateMap<Evaluation, EvaluationDetailRequest>()
    .ForMember(dest => dest.CriteriaEvaluations,
               opt => opt.MapFrom(src => src.EvaluationCriterias))
    .ForMember(dest => dest.ExperienceName,
               opt => opt.MapFrom(src => src.Experience.NameExperiences))
    .ForMember(dest => dest.InstitutionName,
               opt => opt.MapFrom(src => src.Experience.Institution != null ? src.Experience.Institution.Name : string.Empty))
    .ForMember(dest => dest.ThematicLineNames,
               opt => opt.MapFrom(src => src.Experience.ExperienceLineThematics
                                       .Where(x => x.LineThematic != null)
                                       .Select(x => x.LineThematic.Name).ToList()));




        }
    }
}

