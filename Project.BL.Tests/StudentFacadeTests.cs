using Project.BL.Facades;
using Project.BL.Models;
using Project.Common.Tests;
using Project.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace Project.BL.Tests;

public class StudentFacadeTests : FacadeTestsBase
{
    private readonly IStudentFacade _studentFacadeSUT;

    public StudentFacadeTests(ITestOutputHelper output) : base(output)
    {
        _studentFacadeSUT = new StudentFacade(UnitOfWorkFactory, StudentModelMapper);
    }
    
    [Fact]
    public async Task Create_WithNonExistingItem_DoesNotThrow()
    {
        var model = new StudentDetailModel()
        {
            Id = Guid.Empty,
            FirstName = @"Bob",
            LastName = @"Bomb",
        };

        var _ = await _studentFacadeSUT.SaveAsync(model);
    }
    
    /*[Fact]
    public async Task GetById_SeededStudent1()
    {
        var student = await _studentFacadeSUT.GetAsync(StudentSeeds.Student1.Id);

        DeepAssert.Equal(StudentModelMapper.MapToDetailModel(StudentSeeds.Student1), student);
    }*/
    
    [Fact]
    public async Task GetById_NonExistent()
    {
        var student = await _studentFacadeSUT.GetAsync(StudentSeeds.EmptyStudent.Id);

        Assert.Null(student);
    }
    
    [Fact]
    public async Task SeededStudent_DeleteById_Deleted()
    {
        await _studentFacadeSUT.DeleteAsync(StudentSeeds.Student1.Id);

        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        Assert.False(await dbxAssert.Students.AnyAsync(i => i.Id == StudentSeeds.Student1.Id));
    }
    
    [Fact]
    public async Task GetAll_Single_SeededStudent1()
    {
        var students = await _studentFacadeSUT.GetAsync();
        var student = students.Single(i => i.Id == StudentSeeds.Student1.Id);

        DeepAssert.Equal(StudentModelMapper.MapToListModel(StudentSeeds.Student1), student);
    }
}