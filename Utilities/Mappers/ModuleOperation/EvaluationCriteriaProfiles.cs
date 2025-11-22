using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;

namespace Utilities.Mappers.ModuleOperation
{
    public class EvaluationCriteriaProfiles : Profile
    {
        public EvaluationCriteriaProfiles() : base()
        {
            CreateMap <EvaluationCriteriaDTO,  EvaluationCriteria>().ReverseMap();
            CreateMap<EvaluationCriteriaRequest, EvaluationCriteria>().ReverseMap();
            CreateMap<EvaluationCriteria, EvaluationCriteriaRequest>()
    .ForMember(dest => dest.Criteria, opt => opt.MapFrom(src => src.Criteria.Name))
    .ForMember(dest => dest.Evaluation, opt => opt.Ignore());


          





        }
    }
}
