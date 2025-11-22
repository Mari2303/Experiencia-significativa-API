using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos;
using Entity.Dtos.ModelosParametro;
using Entity.Models;
using Entity.Models.ModelosParametros;
using Entity.Requests;
using Entity.Requests.ModulesParamer;
using Service.Interfaces.IModuleBaseService;

namespace Service.Interfaces.ModuleParamer
{
    public interface IStateExperienceService : IBaseModelService<StateExperience, StateExperienceDTO, StateExperienceRequest>
    {
    }
    
}
