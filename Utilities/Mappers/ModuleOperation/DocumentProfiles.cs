using System.Reflection.Metadata;
using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Requests.ModuleOperation;

namespace Utilities.Mappers.ModuleOperation
{
    public class DocumentProfiles : Profile
    {
        public DocumentProfiles() : base()
        {
            CreateMap<DocumentDTO, Document>().ReverseMap();

            CreateMap<DocumentRequest, Document>().ReverseMap();
        }
    }
}
