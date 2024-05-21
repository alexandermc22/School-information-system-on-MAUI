using Project.BL.Facades;
using Project.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;


namespace Project.BL.Tests;

public class GradeFacadeTests : FacadeTestsBase
{
    private readonly IGradeFacade _gradeFacadeSUT;

    public GradeFacadeTests(ITestOutputHelper output) : base(output)
    {
        _gradeFacadeSUT = new GradeFacade(UnitOfWorkFactory, GradeModelMapper);
    }

    /*[Fact]
    public async Task Create_WithNonExistingItem_DoesNotThrow()
    {
        //Arrange
        var model = new GradeDetailModel()
        {
            Id = Guid.Empty,
            SubjectId = SubjectSeeds.Math.Id,
            SubjectName = "Math",
            ActivityId = ActivitySeeds.FirstLecture.Id,
            Description = "Giggity",
            GradeValue = Grade.None,
            GradeDate = DateTime.MinValue
        };

        //Act
        await _gradeFacadeSUT.SaveAsync(model);
    }*/
    
    [Fact]
    public async Task GetById_NonExistent()
    {
        var ingredient = await _gradeFacadeSUT.GetAsync(GradeSeeds.EmptyGrade.Id);

        Assert.Null(ingredient);
    }
    
    [Fact]
    public async Task SeededGrade_DeleteById_Deleted()
    {
        await _gradeFacadeSUT.DeleteAsync(GradeSeeds.Grade1.Id);

        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        Assert.False(await dbxAssert.Grades.AnyAsync(i => i.Id == GradeSeeds.Grade1.Id));
    }
    
    
}