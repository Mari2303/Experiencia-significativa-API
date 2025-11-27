using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModuleOperational;
using Entity.Models;
using Entity.Models.ModelosParametros;
using Entity.Models.ModuleOperation;
using Entity.Models.ModuleSegurity;
using Entity.Requests.EntityData.EntityDetailRequest;
using Entity.Requests.ModuleOperation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Repository.Implementations.ModuleOperationRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Helper;
using Xunit;

public class EvaluationRepositoryTests
{
    // -----------------------------------------
    // CONFIG & HELPERS
    // -----------------------------------------

    private IConfiguration BuildConfiguration()
    {
        var inMemory = new Dictionary<string, string>();
        return new ConfigurationBuilder().AddInMemoryCollection(inMemory).Build();
    }

    private ApplicationContext BuildContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

        return new ApplicationContext(options, BuildConfiguration());
    }

    private EvaluationRepository BuildRepository(
        ApplicationContext ctx,
        Mock<IMapper>? mapperMock = null,
        Mock<IHelper<Evaluation, EvaluationDTO>>? helperMock = null)
    {
        var mapper = mapperMock ?? new Mock<IMapper>();
        var helper = helperMock ?? new Mock<IHelper<Evaluation, EvaluationDTO>>();

        return new EvaluationRepository(ctx, mapper.Object, helper.Object, BuildConfiguration());
    }

    // Helper para evitar errores de Experience obligatoria.
    private Experience BuildExperience(int id, int instId = 1)
    {
        return new Experience
        {
            Id = id,
            InstitucionId = instId,
            Developmenttime = DateTime.UtcNow.ToString("o"),

            Institution = new Institution { Id = instId, Name = "Inst" + instId }
        };
    }

    // -----------------------------------------
    // 1) AddEvaluationAsync
    // -----------------------------------------
    [Fact]
    public async Task AddEvaluationAsync_Should_Add_Evaluation_And_Return_It()
    {
        var ctx = BuildContext("add_eval");
        var repo = BuildRepository(ctx);

        var exp = BuildExperience(1);
        ctx.Experiences.Add(exp);

        var evaluation = new Evaluation
        {
            Id = 1,
            TypeEvaluation = "Inicial",
            ExperienceId = 1,
            State = true
        };

        var result = await repo.AddEvaluationAsync(evaluation);

        Assert.NotNull(result);
        Assert.Equal(1, await ctx.Evaluations.CountAsync());
        Assert.Equal("Inicial", (await ctx.Evaluations.FirstAsync()).TypeEvaluation);
    }

    // -----------------------------------------
    // 2) AddEvaluationCriteriaAsync
    // -----------------------------------------
    [Fact]
    public async Task AddEvaluationCriteriaAsync_Should_Add_Criteria()
    {
        var ctx = BuildContext("add_evalcrit");
        var repo = BuildRepository(ctx);

        var eval = new Evaluation { Id = 1 };
        ctx.Evaluations.Add(eval);

        var evalCrit = new EvaluationCriteria { Id = 1, EvaluationId = 1, CriteriaId = 1 };

        await repo.AddEvaluationCriteriaAsync(evalCrit);

        var stored = await ctx.EvaluationCriterias.FirstOrDefaultAsync();
        Assert.NotNull(stored);
        Assert.Equal(1, stored.Id);
    }

    // -----------------------------------------
    // 3) UpdateCriteriaAsync
    // -----------------------------------------
    [Fact]
    public async Task UpdateCriteriaAsync_Should_Update_Criteria()
    {
        var ctx = BuildContext("update_criteria");
        var repo = BuildRepository(ctx);

        var criteria = new Criteria { Id = 1, Name = "Old" };
        ctx.Criteria.Add(criteria);
        await ctx.SaveChangesAsync();

        criteria.Name = "NewName";
        await repo.UpdateCriteriaAsync(criteria);

        var updated = await ctx.Criteria.FindAsync(1);
        Assert.Equal("NewName", updated.Name);
    }

    // -----------------------------------------
    // 4) GetCriteriaByIdAsync
    // -----------------------------------------
    [Fact]
    public async Task GetCriteriaByIdAsync_Should_Return_Criteria_When_Exists()
    {
        var ctx = BuildContext("get_criteria");
        var repo = BuildRepository(ctx);

        ctx.Criteria.Add(new Criteria { Id = 5, Name = "C1" });
        await ctx.SaveChangesAsync();

        var result = await repo.GetCriteriaByIdAsync(5);
        Assert.NotNull(result);
        Assert.Equal("C1", result.Name);
    }

    // -----------------------------------------
    // 5) GetExperienceWithInstitutionAsync
    // -----------------------------------------
    [Fact]
    public async Task GetExperienceWithInstitutionAsync_Should_Include_Evaluations_And_Institution_And_LineThematics()
    {
        var ctx = BuildContext("exp_with_inst");
        var repo = BuildRepository(ctx);

        var exp = BuildExperience(10);

        var eval = new Evaluation { Id = 1, ExperienceId = 10, TypeEvaluation = "Inicial" };
        var lineThematic = new LineThematic { Id = 2, Name = "LT1" };
        var expLine = new ExperienceLineThematic
        {
            Id = 1,
            ExperienceId = 10,
            LineThematic = lineThematic,
            LineThematicId = 2
        };

        ctx.Experiences.Add(exp);
        ctx.Evaluations.Add(eval);
        ctx.LineThematics.Add(lineThematic);
        ctx.ExperienceLineThematics.Add(expLine);
        await ctx.SaveChangesAsync();

        var res = await repo.GetExperienceWithInstitutionAsync(10);

        Assert.NotNull(res);
        Assert.Equal(10, res.Id);
        Assert.NotNull(res.Institution);
        Assert.True(res.Evaluations.Any());
        Assert.NotEmpty(res.ExperienceLineThematics);
    }

    // -----------------------------------------
    // 6) GetEvaluationDetailAsync
    // -----------------------------------------
    [Fact]
    public async Task GetEvaluationDetailAsync_Should_Map_To_Request_And_Populate_User_Info()
    {
        var ctx = BuildContext("eval_detail");

        var mapperMock = new Mock<IMapper>();
        var helperMock = new Mock<IHelper<Evaluation, EvaluationDTO>>();

        var person = new Person
        {
            Id = 99,
            Email = "u@example.com",
            FirstName = "UserF",
            FirstLastName = "Last"
        };

        var user = new User
        {
            Id = 2,
            Username = "user1",
            Person = person,
            PersonId = person.Id
        };

        var exp = BuildExperience(200, 3);

        var eval = new Evaluation
        {
            Id = 100,
            User = user,
            UserId = user.Id,
            Experience = exp,
            ExperienceId = exp.Id,
            EvaluationCriterias = new List<EvaluationCriteria>()
        };

        ctx.Persons.Add(person);
        ctx.Users.Add(user);
        ctx.Experiences.Add(exp);
        ctx.Evaluations.Add(eval);
        await ctx.SaveChangesAsync();

        mapperMock.Setup(m => m.Map<EvaluationDetailRequest>(It.IsAny<Evaluation>()))
            .Returns(new EvaluationDetailRequest());

        var repo = new EvaluationRepository(ctx, mapperMock.Object, helperMock.Object, BuildConfiguration());

        var req = await repo.GetEvaluationDetailAsync(100);

        Assert.NotNull(req);
        Assert.Equal("user1", req.UserName);
        Assert.Equal("u@example.com", req.Email);
    }

    [Fact]
    public async Task GetEvaluationDetailAsync_Should_Throw_When_NotFound()
    {
        var ctx = BuildContext("eval_detail_notfound");
        var mapperMock = new Mock<IMapper>();
        var helperMock = new Mock<IHelper<Evaluation, EvaluationDTO>>();
        var repo = new EvaluationRepository(ctx, mapperMock.Object, helperMock.Object, BuildConfiguration());

        await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            await repo.GetEvaluationDetailAsync(9999));
    }

    // -----------------------------------------
    // 7) GetByExperienceAndTypeAsync
    // -----------------------------------------
    [Fact]
    public async Task GetByExperienceAndTypeAsync_Should_Return_Evaluation_When_Matches()
    {
        var ctx = BuildContext("by_exp_type");
        var repo = BuildRepository(ctx);

        var exp = BuildExperience(50);
        ctx.Experiences.Add(exp);

        var eval = new Evaluation { Id = 1, ExperienceId = 50, TypeEvaluation = "Inicial", State = true };
        ctx.Evaluations.Add(eval);

        await ctx.SaveChangesAsync();

        var res = await repo.GetByExperienceAndTypeAsync(50, "Inicial");

        Assert.NotNull(res);
        Assert.Equal(1, res.Id);
    }

    // -----------------------------------------
    // 8) UpdateEvaluationAsync
    // -----------------------------------------
    [Fact]
    public async Task UpdateEvaluationAsync_Should_Replace_Criteria_And_Return_Evaluation()
    {
        var ctx = BuildContext("update_eval");
        var repo = BuildRepository(ctx);

        var exp = BuildExperience(7);
        ctx.Experiences.Add(exp);

        var eval = new Evaluation { Id = 7, ExperienceId = 7 };
        ctx.Evaluations.Add(eval);

        ctx.EvaluationCriterias.Add(new EvaluationCriteria
        {
            Id = 1,
            EvaluationId = 7,
            CriteriaId = 1
        });

        await ctx.SaveChangesAsync();

        var newCriteria = new List<EvaluationCriteria>
        {
            new EvaluationCriteria { Id = 10, EvaluationId = 7, CriteriaId = 2 }
        };

        var result = await repo.UpdateEvaluationAsync(eval, newCriteria);

        Assert.NotNull(result);

        var criterias = ctx.EvaluationCriterias.Where(c => c.EvaluationId == 7).ToList();
        Assert.Single(criterias);
        Assert.Equal(2, criterias.First().CriteriaId);
    }

    // -----------------------------------------
    // 9) SaveChangesAsync
    // -----------------------------------------
    [Fact]
    public async Task SaveChangesAsync_Should_Call_SaveChanges()
    {
        var ctx = BuildContext("save_changes");
        var repo = BuildRepository(ctx);

        ctx.Criteria.Add(new Criteria { Id = 33, Name = "Tmp" });
        await repo.SaveChangesAsync();

        Assert.Equal(1, await ctx.Criteria.CountAsync());
    }

    // -----------------------------------------
    // 10) UpdateEvaluationPdfUrlAsync
    // -----------------------------------------
    [Fact]
    public async Task UpdateEvaluationPdfUrlAsync_Should_Update_Url()
    {
        var ctx = BuildContext("upd_pdf");
        var repo = BuildRepository(ctx);

        // UrlEvaPdf es REQUIRED en el modelo: no usar null al crear la entidad
        var eval = new Evaluation { Id = 55, UrlEvaPdf = "", ExperienceId = 1 };
        ctx.Evaluations.Add(eval);
        await ctx.SaveChangesAsync();

        await repo.UpdateEvaluationPdfUrlAsync(55, "http://pdf.url/doc.pdf");

        var updated = await ctx.Evaluations.FindAsync(55);
        Assert.Equal("http://pdf.url/doc.pdf", updated.UrlEvaPdf);
    }


    [Fact]
    public async Task UpdateEvaluationPdfUrlAsync_Should_Throw_When_NotFound()
    {
        var ctx = BuildContext("upd_pdf_notfound");
        var repo = BuildRepository(ctx);

        await Assert.ThrowsAsync<Exception>(async () =>
            await repo.UpdateEvaluationPdfUrlAsync(999, "x"));
    }

    // -----------------------------------------
    // 11) GetEvaluationByIdTrackedAsync
    // -----------------------------------------
    [Fact]
    public async Task GetEvaluationByIdTrackedAsync_Should_Return_Evaluation_With_Includes()
    {
        var ctx = BuildContext("get_tracked");
        var repo = BuildRepository(ctx);

        var exp = BuildExperience(6, 2);
        var crit = new Criteria { Id = 3, Name = "C" };
        var eval = new Evaluation { Id = 99, Experience = exp, ExperienceId = exp.Id };
        var ec = new EvaluationCriteria
        {
            Id = 100,
            EvaluationId = 99,
            Criteria = crit,
            CriteriaId = crit.Id
        };

        ctx.Criteria.Add(crit);
        ctx.Experiences.Add(exp);
        ctx.Evaluations.Add(eval);
        ctx.EvaluationCriterias.Add(ec);
        await ctx.SaveChangesAsync();

        var res = await repo.GetEvaluationByIdTrackedAsync(99);

        Assert.NotNull(res);
        Assert.Equal(99, res.Id);
        Assert.NotEmpty(res.EvaluationCriterias);
    }

    // -----------------------------------------
    // 12) GetExperiencesWithInitialEvaluationAsync
    // -----------------------------------------
    [Fact]
    public async Task GetExperiencesWithInitialEvaluationAsync_Should_Return_Experiences()
    {
        var ctx = BuildContext("exp_initial");
        var repo = BuildRepository(ctx);

        var exp = BuildExperience(201);
        var evalInit = new Evaluation { Id = 300, ExperienceId = 201, TypeEvaluation = "Inicial" };

        ctx.Experiences.Add(exp);
        ctx.Evaluations.Add(evalInit);
        await ctx.SaveChangesAsync();

        var list = (await repo.GetExperiencesWithInitialEvaluationAsync()).ToList();

        Assert.NotEmpty(list);
        Assert.Contains(list, e => e.Id == 201);
    }

    // -----------------------------------------
    // 13) GetExperiencesWithFinalEvaluationAsync
    // -----------------------------------------
    [Fact]
    public async Task GetExperiencesWithFinalEvaluationAsync_Should_Return_Experiences()
    {
        var ctx = BuildContext("exp_final");
        var repo = BuildRepository(ctx);

        var exp = BuildExperience(301);
        var evalFinal = new Evaluation { Id = 400, ExperienceId = 301, TypeEvaluation = "Final" };

        ctx.Experiences.Add(exp);
        ctx.Evaluations.Add(evalFinal);
        await ctx.SaveChangesAsync();

        var list = (await repo.GetExperiencesWithFinalEvaluationAsync()).ToList();

        Assert.NotEmpty(list);
        Assert.Contains(list, e => e.Id == 301);
    }

    // -----------------------------------------
    // 14) GetExperiencesWithoutEvaluationAsync
    // -----------------------------------------
    [Fact]
    
    public async Task GetExperiencesWithoutEvaluationAsync_Should_Return_Only_Without_Evaluations()
    {
        var ctx = BuildContext("exp_without");
        var repo = BuildRepository(ctx);

        // Crear 1 sola institución
        var inst = new Institution { Id = 1, Name = "Inst 1" };
        ctx.Institutions.Add(inst);

        var expWithout = new Experience
        {
            Id = 401,
            InstitucionId = 1,
            Institution = inst,
            Developmenttime = DateTime.UtcNow.ToString("o")
        };

        var expWith = new Experience
        {
            Id = 402,
            InstitucionId = 1,
            Institution = inst,
            Developmenttime = DateTime.UtcNow.ToString("o")
        };

        var eval = new Evaluation
        {
            Id = 500,
            ExperienceId = 402,
            TypeEvaluation = "Inicial",
            UrlEvaPdf = "x.pdf"
        };

        ctx.Experiences.AddRange(expWithout, expWith);
        ctx.Evaluations.Add(eval);
        await ctx.SaveChangesAsync();

        var list = (await repo.GetExperiencesWithoutEvaluationAsync()).ToList();

        Assert.Single(list);
        Assert.Equal(401, list.First().Id);
    }

}

