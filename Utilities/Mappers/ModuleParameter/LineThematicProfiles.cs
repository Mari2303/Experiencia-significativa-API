using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Dtos;
using Entity.Dtos.ModelosParametro;
using Entity.Models;
using Entity.Models.ModelosParametros;
using Entity.Requests.ModulesParamer;

namespace Utilities.Mappers.ModulesParamer
{
    public class LineThematicProfiles : Profile
    {
        public LineThematicProfiles() : base()
        {
           

            CreateMap<LineThematicDTO, LineThematic>().ReverseMap();


            CreateMap<LineThematicRequest, LineThematic>().ReverseMap();

        }
    }
}

