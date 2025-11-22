using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.ModelosParametro;
using Entity.Models.ModelosParametros;
using Entity.Requests.ModulesParamer;
using Repository.Interfaces.ModuleParamer;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.ModuleParamer;

namespace Service.Implementations.ModuleParamer
{
    public class StateExperienceService : BaseModelService<StateExperience, StateExperienceDTO, StateExperienceRequest>, IStateExperienceService
    {
        private readonly IStateExperienceRepository _stateRepository;


        public StateExperienceService(IStateExperienceRepository stateRepository) : base(stateRepository)
        {
            _stateRepository = stateRepository;
        }
    
    }
}
