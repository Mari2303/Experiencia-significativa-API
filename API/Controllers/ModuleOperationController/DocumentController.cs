using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace API.Controllers.ModuleOperationController
{
    public class DocumentController : BaseModelController<Document, DocumentDTO, DocumentRequest>
    {
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;
        public DocumentController(IBaseModelService<Document, DocumentDTO, DocumentRequest> baseService, IDocumentService documentService, IMapper mapper) : base(baseService, mapper)
        {
            _documentService = documentService;
            _mapper = mapper;
        }
    }
}
