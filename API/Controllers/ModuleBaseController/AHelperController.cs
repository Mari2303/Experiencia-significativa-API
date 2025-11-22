using Entity.Dtos;
using Entity.Models;
using Entity.Requests.ModuleSegurity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ModuleBaseController
{
    public abstract class AHelperController : ControllerBase
    {
        public abstract Task<ActionResult<IEnumerable<DataSelectRequest>>> GetEnum(string enumName);
    }
}