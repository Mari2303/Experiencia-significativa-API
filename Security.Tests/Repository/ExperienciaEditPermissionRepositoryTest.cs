using Entity.Context;
using Entity.Models.ModuleOperation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Implementations.ModuleOperationRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

public class ExperienceEditPermissionRepositoryTests
{
    private ApplicationContext BuildContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

        // Crear configuración falsa (mock)
        var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();

        return new ApplicationContext(options, configuration);
    }


    private ExperienceEditPermissionRepository BuildRepository(ApplicationContext ctx)
    {
        return new ExperienceEditPermissionRepository(ctx);
    }

   
    [Fact]
    public async Task GetByExperienceIdAsync_Should_Return_Permission_When_Exists()
    {
        var ctx = BuildContext("get_by_exp");
        var repo = BuildRepository(ctx);

        var perm = new ExperienceEditPermission
        {
            Id = 1,
            ExperienceId = 300,
            UserId = 10,
            Approved = true,
            ExpiresAt = new DateTime(2025, 12, 1)
        };

        ctx.ExperienceEditPermissions.Add(perm);
        await ctx.SaveChangesAsync();

        var result = await repo.GetByExperienceIdAsync(300);

        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal(300, result.ExperienceId);
    }

    [Fact]
    public async Task GetByExperienceIdAsync_Should_Return_Null_When_Not_Exists()
    {
        var ctx = BuildContext("get_by_exp_null");
        var repo = BuildRepository(ctx);

        var result = await repo.GetByExperienceIdAsync(999);

        Assert.Null(result);
    }


    [Fact]
    public async Task AddAsync_Should_Insert_Permission()
    {
        var ctx = BuildContext("add_exp");
        var repo = BuildRepository(ctx);

        var perm = new ExperienceEditPermission
        {
            Id = 7,
            ExperienceId = 200,
            UserId = 50,
            Approved = false,
            ExpiresAt = new DateTime(2025, 12, 1)
        };

        await repo.AddAsync(perm);

        var saved = await ctx.ExperienceEditPermissions.FindAsync(7);

        Assert.NotNull(saved);
        Assert.Equal(200, saved.ExperienceId);
    }

 // Opción A — comparar DateTime con DateTime (recomendada)
[Fact]
public async Task UpdateAsync_Should_Update_Values()
{
    var ctx = BuildContext("update_exp");
    var repo = BuildRepository(ctx);

    var perm = new ExperienceEditPermission
    {
        Id = 22,
        ExperienceId = 100,
        UserId = 5,
        Approved = false,
        ExpiresAt = new DateTime(2024, 1, 1)
    };

    ctx.ExperienceEditPermissions.Add(perm);
    await ctx.SaveChangesAsync();

    // Modify fields
    perm.Approved = true;
    perm.ExpiresAt = new DateTime(2030, 10, 10); // <-- CORRECTO: new DateTime(...)

    await repo.UpdateAsync(perm);

    var updated = await ctx.ExperienceEditPermissions.FindAsync(22);

    Assert.True(updated.Approved);
    Assert.Equal(new DateTime(2030, 10, 10), updated.ExpiresAt); // comparar DateTimes
}


    




}


