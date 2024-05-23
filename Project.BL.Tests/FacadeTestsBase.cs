using Project.BL.Mappers;
using Project.Common.Tests;
using Project.Common.Tests.Factories;
using Project.DAL;
using Project.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
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
        
        
        GradeModelMapper = new GradeModelMapper();
        ActivityModelMapper = new ActivityModelMapper(GradeModelMapper);
        StudentSubjectsModelMapper = new StudentSubjectsModelMapper();
        StudentModelMapper = new StudentModelMapper(StudentSubjectsModelMapper);
        SubjectStudentsModelMapper = new SubjectStudentsModelMapper();
        SubjectModelMapper = new SubjectModelMapper(SubjectStudentsModelMapper);
        
        UnitOfWorkFactory = new UnitOfWorkFactory(DbContextFactory);
        
    }

    protected IDbContextFactory<ProjectDbContext> DbContextFactory { get; }
    protected GradeModelMapper GradeModelMapper { get; } 
    protected ActivityModelMapper ActivityModelMapper { get; }
    protected StudentSubjectsModelMapper StudentSubjectsModelMapper { get; }
    protected StudentModelMapper StudentModelMapper { get; }
    protected SubjectStudentsModelMapper SubjectStudentsModelMapper { get;  }
    protected SubjectModelMapper SubjectModelMapper { get;  }
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