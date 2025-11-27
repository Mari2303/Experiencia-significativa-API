using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityCreateRequest;
using Entity.Requests.EntityData.EntityDetailRequest;
using Entity.Requests.EntityData.EntityUpdateRequest;
using Entity.Requests.ModuleBase;
using Entity.Requests.ModuleOperation;
using Microsoft.Extensions.Options;
using Moq;
using Repository.Interfaces.IModuleOperationRepository;
using Service.Extensions;
using Service.Implementations.ModelOperationService;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.CreatedPdf.templatePdfs;
using Utilities.Email.Interfaces;
using Xunit;

public class EvaluationServiceTests
{
    private readonly Mock<IEvaluationRepository> _repoMock = new();
    private readonly Mock<SupabaseStorageService> _storageMock = new();
    private readonly Mock<IEmailEvaluationBrevoService> _mailMock = new();

    private readonly EvaluationService _service;

    public EvaluationServiceTests()
    {
        var pdfSettings = Options.Create(new PdfSettingsRequest
        {
            LogoUrl = "https://logo.test.com/logo.png"
        });

        _service = new EvaluationService(
            _repoMock.Object,
            _storageMock.Object,
            _mailMock.Object,
            pdfSettings
        );
    }


    [Fact]
    public async Task CreateEvaluationAsync_Should_Create_And_Return_Detail()
    {
        // Arrange
        var createRequest = new EvaluationCreateRequest
        {
            ExperienceId = 1,
            EvaluationCriteriaDetail = new List<EvaluationCriteriaDetailRequest>()
        };

        _repoMock.Setup(r => r.GetExperienceWithInstitutionAsync(1))
                 .ReturnsAsync(new Experience());

        _repoMock.Setup(r => r.AddEvaluationAsync(It.IsAny<Evaluation>()))
                 .ReturnsAsync(new Evaluation { Id = 10 });

        _repoMock.Setup(r => r.GetEvaluationDetailAsync(10))
            .ReturnsAsync(new EvaluationDetailRequest
            {
             
                Email = "test@test.com",
                UserName = "Carlos",
                EvaluationResult = "Aprobado"
            });

        // Act
        var result = await _service.CreateEvaluationAsync(createRequest);

        // Assert
        Assert.NotNull(result);
      
        _repoMock.Verify(r => r.AddEvaluationAsync(It.IsAny<Evaluation>()), Times.Once);
        _repoMock.Verify(r => r.GetEvaluationDetailAsync(10), Times.Once);
    }


    [Fact]
    public async Task UpdateEvaluationAsync_Should_Update_Entity()
    {
        // Arrange
        var eval = new Evaluation { Id = 5 };
        var updateRequest = new EvaluationUpdateRequest();

        _repoMock.Setup(r => r.GetEvaluationByIdTrackedAsync(5))
            .ReturnsAsync(eval);

        _repoMock.Setup(r => r.GetEvaluationDetailAsync(5))
            .ReturnsAsync(new EvaluationDetailRequest
            {
                
                Email = "test@test.com",
                UserName = "Maria",
                EvaluationResult = "Bueno"
            });

        // Act
        var result = await _service.UpdateEvaluationAsync(5, updateRequest);

        // Assert
        Assert.NotNull(result);
        

        _repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        _mailMock.Verify(m => m.SendEvaluationResultEmailAsync(
            "test@test.com", "Maria", "Bueno"), Times.Once);
    }

   

   
    [Fact]
    public async Task FilterInitialEvaluationAsync_Should_Return_List()
    {
        _repoMock.Setup(r => r.GetExperiencesWithInitialEvaluationAsync())
            .ReturnsAsync(new List<Experience> { new Experience() });

        var result = await _service.FilterInitialEvaluationAsync();

        Assert.Single(result);
    }

    [Fact]
    public async Task FilterFinalEvaluationAsync_Should_Return_List()
    {
        _repoMock.Setup(r => r.GetExperiencesWithFinalEvaluationAsync())
            .ReturnsAsync(new List<Experience> { new Experience() });

        var result = await _service.FilterFinalEvaluationAsync();

        Assert.Single(result);
    }

    [Fact]
    public async Task FilterWithoutEvaluationAsync_Should_Return_List()
    {
        _repoMock.Setup(r => r.GetExperiencesWithoutEvaluationAsync())
            .ReturnsAsync(new List<Experience> { new Experience() });

        var result = await _service.FilterWithoutEvaluationAsync();

        Assert.Single(result);
    }
}

