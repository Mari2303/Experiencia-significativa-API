using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Repository.Interfaces.IModuleOperationRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace Service.Implementations.ModelOperationService
{
    public class DocumentService : BaseModelService<Document, DocumentDTO, DocumentRequest>, IDocumentService
    { 
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository) : base(documentRepository)
        {
            _documentRepository = documentRepository;
        }
    }
}
