using API.Controllers.ModuleOperationController;
using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityCreateRequest;
using Entity.Requests.EntityData.EntityDetailRequest;
using Entity.Requests.EntityData.EntityUpdateRequest;
using Entity.Requests.ModuleOperation;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.ModelOperationService;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class EvaluationControllerTests
{
    private readonly Mock<IEvaluationService> _evalServiceMock;
    private readonly Mock<IBaseModelService<Evaluation, EvaluationDTO, EvaluationRequest>> _baseServiceMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly EvaluationController _controller;

    public EvaluationControllerTests()
    {
        _evalServiceMock = new Mock<IEvaluationService>();
        _baseServiceMock = new Mock<IBaseModelService<Evaluation, EvaluationDTO, EvaluationRequest>>();
        _mapperMock = new Mock<IMapper>();

        _controller = new EvaluationController(
            _baseServiceMock.Object,
            _evalServiceMock.Object,
            _mapperMock.Object
        );
    }

  
    [Fact]
    public async Task Create_ReturnsOk_WhenValid()
    {
        // Arrange
        var request = new EvaluationCreateRequest
        {
            TypeEvaluation = "Inicial",
            Comments = "Todo bien"
        };

        var expected = new EvaluationDetailRequest
        {
            TypeEvaluation = "Inicial",
            Comments = "Todo bien",
            ExperienceName = "Exp 1"
        };

        _evalServiceMock
            .Setup(s => s.CreateEvaluationAsync(It.IsAny<EvaluationCreateRequest>()))
            .ReturnsAsync(expected);

        // Act
        var result = await _controller.Create(request);

        // Assert
        var ok = Assert.IsType<OkObjectResult>(result);
        var returned = Assert.IsType<EvaluationDetailRequest>(ok.Value);
        Assert.Equal("Inicial", returned.TypeEvaluation);
    }

  
    [Fact]
    public async Task Update_ReturnsOk_WhenValid()
    {
        // Arrange
        var request = new EvaluationUpdateRequest
        {
            Comments = "Actualizado"
        };

        var expected = new EvaluationDetailRequest
        {
            TypeEvaluation = "Final",
            Comments = "Actualizado"
        };

        _evalServiceMock
            .Setup(s => s.UpdateEvaluationAsync(1, It.IsAny<EvaluationUpdateRequest>()))
            .ReturnsAsync(expected);

        // Act
        var result = await _controller.Update(1, request);

        // Assert
        var ok = Assert.IsType<OkObjectResult>(result);
        var returned = Assert.IsType<EvaluationDetailRequest>(ok.Value);
        Assert.Equal("Actualizado", returned.Comments);
    }

    [Fact]
    public async Task GeneratePdf_ReturnsOk()
    {
        // Arrange
        _evalServiceMock
            .Setup(s => s.GenerateAndAttachPdfAsync(1))
            .ReturnsAsync("PDF generado");

        // Act
        var result = await _controller.GeneratePdf(1);

        // Assert
        var ok = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("PDF generado", ok.Value);
    }

   
    [Fact]
    public async Task FilterInitial_ReturnsOk()
    {
        // Arrange
        var list = new List<Experience>
        {
            new Experience { Id = 1, NameExperiences = "Exp 1" }
        };

        _evalServiceMock
            .Setup(s => s.FilterInitialEvaluationAsync())
            .ReturnsAsync(list);

        // Act
        var result = await _controller.FilterInitial();

        // Assert
        var ok = Assert.IsType<OkObjectResult>(result);
        var returned = Assert.IsAssignableFrom<IEnumerable<Experience>>(ok.Value);
        Assert.Single(returned);
    }
}


