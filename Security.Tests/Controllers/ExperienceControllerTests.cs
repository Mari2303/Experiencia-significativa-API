using API.Controllers.ModuleOperationController;
using AutoMapper;
using Entity.Dtos.ModuleOperation;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityCreateRequest;
using Entity.Requests.EntityData.EntityDetailRequest;
using Entity.Requests.EntityData.EntityUpdateRequest;
using Entity.Requests.ModuleOperation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.ModelOperationService;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

public class ExperienceControllerTests
{
    private readonly Mock<IExperienceService> _serviceMock;
    private readonly Mock<IBaseModelService<Experience, ExperienceDTO, ExperienceRequest>> _baseMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly ExperienceController _controller;

    public ExperienceControllerTests()
    {
        _serviceMock = new Mock<IExperienceService>();
        _baseMock = new Mock<IBaseModelService<Experience, ExperienceDTO, ExperienceRequest>>();
        _mapperMock = new Mock<IMapper>();

        _controller = new ExperienceController(_baseMock.Object, _serviceMock.Object, _mapperMock.Object);
    }

    // ---------------------------------------------------------
    // REGISTER
    // ---------------------------------------------------------
    [Fact]
    public async Task Register_ReturnsOk_WhenValid()
    {
        var request = new ExperienceCreateRequest { NameExperiences = "Test" };

        var returned = new Experience { NameExperiences = "Test" };

        _serviceMock
            .Setup(s => s.RegisterExperienceAsync(It.IsAny<ExperienceCreateRequest>()))
            .ReturnsAsync(returned);

        var result = await _controller.Register(request);

        var ok = Assert.IsType<OkObjectResult>(result);
        Assert.IsType<Experience>(ok.Value);
    }

    [Fact]
    public async Task Register_ReturnsBadRequest_WhenNull()
    {
        var result = await _controller.Register(null);

        var bad = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("El DTO no puede estar vacío.", bad.Value);
    }

    [Fact]
    public async Task Register_Returns500_WhenException()
    {
        _serviceMock
            .Setup(s => s.RegisterExperienceAsync(It.IsAny<ExperienceCreateRequest>()))
            .ThrowsAsync(new System.Exception("Error"));

        var result = await _controller.Register(new ExperienceCreateRequest());

        var resp = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, resp.StatusCode);
    }

  

    [Fact]
    public async Task Detail_ReturnsOk_WhenFound()
    {
        var detail = new ExperienceDetailRequest { ExperienceId = 1 };

        _serviceMock.Setup(s => s.GetDetailByIdAsync(1))
                    .ReturnsAsync(detail);

        var result = await _controller.Detail(1);

        var ok = Assert.IsType<OkObjectResult>(result);
        Assert.IsType<ExperienceDetailRequest>(ok.Value);
    }

    [Fact]
    public async Task Detail_ReturnsNotFound_WhenNull()
    {
        _serviceMock.Setup(s => s.GetDetailByIdAsync(1))
                    .ReturnsAsync((ExperienceDetailRequest)null);

        var result = await _controller.Detail(1);

        Assert.IsType<NotFoundResult>(result);
    }

  
    [Fact]
    public async Task Patch_ReturnsOk_WhenPatched()
    {
        var request = new ExperienceUpdateRequest();

        _serviceMock.Setup(s => s.PatchAsync(request))
                    .ReturnsAsync(true);

        var result = await _controller.Patch(request);

        var ok = Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Patch_ReturnsBadRequest_WhenInvalidModel()
    {
        _controller.ModelState.AddModelError("error", "invalid");

        var result = await _controller.Patch(new ExperienceUpdateRequest());

        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task Patch_ReturnsNotFound_WhenNotPatched()
    {
        var request = new ExperienceUpdateRequest();

        _serviceMock.Setup(s => s.PatchAsync(request))
                    .ReturnsAsync(false);

        var result = await _controller.Patch(request);

        Assert.IsType<NotFoundResult>(result);
    }

    
    [Fact]
    public async Task GetExperiences_ReturnsOk()
    {
        var claims = new List<Claim>
        {
            new Claim("id", "10"),
            new Claim(ClaimTypes.Role, "USER")
        };

        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(claims, "mock"))
            }
        };

        _serviceMock
            .Setup(s => s.GetExperiencesAsync("USER", 10))
            .ReturnsAsync(new List<Experience>());

        var result = await _controller.GetExperiences();

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task RequestEdit_ReturnsOk()
    {
        _serviceMock.Setup(s => s.RequestEditAsync(1, 5))
                    .Returns(Task.CompletedTask);

        var result = await _controller.RequestEdit(1, 5);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task ApproveEdit_ReturnsOk()
    {
        _serviceMock.Setup(s => s.ApproveEditAsync(1))
                    .Returns(Task.CompletedTask);

        var result = await _controller.ApproveEdit(1);

        Assert.IsType<OkObjectResult>(result);
    }

   
    [Fact]
    public async Task GetAllPermissions_ReturnsOk()
    {
        _serviceMock.Setup(s => s.GetAllAsync())
                    .ReturnsAsync(new List<ExperienceEditPermissionDTO>());

        var result = await _controller.GetAllPermissions();

        Assert.IsType<OkObjectResult>(result);
    }

  
    [Fact]
    public async Task GetDetailForm_ReturnsOk_WhenFound()
    {
        var exp = new Experience { NameExperiences = "Test" };

        _serviceMock.Setup(s => s.GetDetailAsync(1))
                    .ReturnsAsync(exp);

        var result = await _controller.GetDetail(1);

        var ok = Assert.IsType<OkObjectResult>(result);
        Assert.IsType<Experience>(ok.Value);
    }

    [Fact]
    public async Task GetDetailForm_ReturnsNotFound_WhenNull()
    {
        _serviceMock.Setup(s => s.GetDetailAsync(1))
                    .ReturnsAsync((Experience)null);

        var result = await _controller.GetDetail(1);

        var notFound = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("No se encontró la experiencia.", notFound.Value);
    }
}

