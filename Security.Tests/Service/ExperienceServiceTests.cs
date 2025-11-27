using Entity.Dtos.ModuleOperational;
using Entity.Models;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityCreateRequest;
using Entity.Requests.EntityData.EntityUpdateRequest;
using Entity.Requests.ModuleBase;
using Entity.Requests.ModuleOperation;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using Moq;
using Repository.Interfaces.IModuleOperationRepository;
using Repository.Interfaces.IModuleSegurityRepository;
using Service.Implementations.ModelOperationService;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.CreatedPdf.Service;
using Xunit;

// === INTERFACES ADICIONALES NECESARIAS PARA TESTING ===

public interface IExperienceStorage
{
    Task<string> UploadExperiencePdfToSupabase(byte[] pdfBytes, int experienceId);
}

public interface IExperiencePdfService
{
    Task<byte[]?> LoadLogoAsync(string url);
    byte[] Generate(Experience exp, byte[] logo);
}


// =========================
//   TESTS DEL SERVICIO
// =========================

public class ExperienceServiceTests
{
    // =======================================================
    //    HELPERS PARA CONSTRUIR EL SERVICIO CON MOCKS
    // =======================================================
    private ExperienceService BuildService(
        Mock<IExperienceRepository>? repo = null,
        Mock<SubeBaseExperienceStorage>? storage = null,
        Mock<IHubContext<NotificationHub>>? hub = null,
        Mock<IExperienceEditPermissionRepository>? permRepo = null,
        Mock<IUserRepository>? userRepo = null
    )
    {
        repo ??= new Mock<IExperienceRepository>();
        storage ??= new Mock<SubeBaseExperienceStorage>();
        hub ??= new Mock<IHubContext<NotificationHub>>();
        permRepo ??= new Mock<IExperienceEditPermissionRepository>();
        userRepo ??= new Mock<IUserRepository>();

        var options = Options.Create(new PdfSettingsRequest
        {
            LogoUrl = "https://test/logo.png"
        });

        // Mock SignalR Clients
        var mockClients = new Mock<IHubClients>();
        var mockAll = new Mock<IClientProxy>();

        hub.Setup(h => h.Clients).Returns(mockClients.Object);
        mockClients.Setup(c => c.All).Returns(mockAll.Object);

        return new ExperienceService(
            repo.Object,
            storage.Object,
            options,
            hub.Object,
            permRepo.Object,
            userRepo.Object
        );
    }


    [Fact]
    public async Task RequestEditAsync_Should_Create_Permission()
    {
        var repo = new Mock<IExperienceRepository>();
        repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Experience());

        var permRepo = new Mock<IExperienceEditPermissionRepository>();
        permRepo.Setup(r => r.GetByExperienceIdAsync(1)).ReturnsAsync((ExperienceEditPermission)null);

        var service = BuildService(repo: repo, permRepo: permRepo);

        // Act
        await service.RequestEditAsync(1, 20);

        // Assert
        permRepo.Verify(r => r.AddAsync(It.IsAny<ExperienceEditPermission>()), Times.Once);
    }
}


