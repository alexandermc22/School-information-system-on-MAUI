using Project.Common.Tests;
using Project.Common.Tests.Factories;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace Project.DAL.Tests;

public class  DbContextTestsBase : IAsyncLifetime
{
    protected DbContextTestsBase(ITestOutputHelper output)
    {
        XUnitTestOutputConverter converter = new(output);
        Console.SetOut(converter);

        DbContextFactory = new DbContextSqLiteTestingFactory(GetType().FullName!, seedTestingData: true);
        ProjectDbContextSUT = DbContextFactory.CreateDbContext();
    }

    protected IDbContextFactory<ProjectDbContext> DbContextFactory { get; }
    protected ProjectDbContext ProjectDbContextSUT { get; }


    public async Task InitializeAsync()
    {
        await ProjectDbContextSUT.Database.EnsureDeletedAsync();
        await ProjectDbContextSUT.Database.EnsureCreatedAsync();
    }

    public async Task DisposeAsync()
    {
        await ProjectDbContextSUT.Database.EnsureDeletedAsync();
        await ProjectDbContextSUT.DisposeAsync();
    }
}