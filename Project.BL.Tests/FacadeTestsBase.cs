using Project.BL.Mappers;
using Project.DAL;
using Project.DAL.UnitOfWork;
using Project.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Project.Common.Tests;
using Microsoft.EntityFrameworkCore.Internal;
using Project.DAL.Tests;
using Xunit;
using Xunit.Abstractions;


namespace Project.BL.Tests;



public class FacadeTestsBase: IAsyncLifetime
{
    protected FacadeTestsBase(ITestOutputHelper output)
    {
        XUnitTestOutputConverter converter = new(output);
        Console.SetOut(converter);
        
        DbContextFactory = new DbContextSqLiteTestingFactory(GetType().FullName!, seedTestingData: true);


        ActivityListDetailModelMapper = new ActivityListDetailModelMapper();
        GradeListDetailModelMapper = new GradeListDetailModelMapper();
        StudentListModelMapper = new StudentListModelMapper();
        SubjectListModelMapper = new SubjectListModelMapper();
        UnitOfWorkFactory = new UnitOfWorkFactory(DbContextFactory);



    }

    protected IDbContextFactory<ProjectDbContext> DbContextFactory { get; }
    protected ActivityListDetailModelMapper ActivityListDetailModelMapper { get; }
    protected GradeListDetailModelMapper GradeListDetailModelMapper { get; } 
    protected StudentListModelMapper StudentListModelMapper { get; }
    protected SubjectListModelMapper SubjectListModelMapper { get; }
    protected UnitOfWorkFactory UnitOfWorkFactory { get; }
    
    public async Task InitializeAsync()
    {
        await using var dbx =  DbContextFactory.CreateDbContext();
        await dbx.Database.EnsureDeletedAsync();
        await dbx.Database.EnsureCreatedAsync();
    }

    public async Task DisposeAsync()
    {
        await using var dbx = DbContextFactory.CreateDbContext();
        await dbx.Database.EnsureDeletedAsync();
    }

    
}