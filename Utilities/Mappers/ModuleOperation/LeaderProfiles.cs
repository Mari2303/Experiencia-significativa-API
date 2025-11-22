using AutoMapper;
using Entity.Dtos.ModuleOperation;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;

namespace Utilities.Mappers.ModuleOperation
{
    public class LeaderProfiles : Profile
    {
        public LeaderProfiles() : base()
        {
            CreateMap<LeaderDTO, Leader>().ReverseMap();
            CreateMap<LeaderRequest, Leader>().ReverseMap();

        }
    }
}
