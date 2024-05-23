/*
using Xunit;
using Xunit.Abstractions;
using Project.BL.Models;
using Project.BL.Facades;
using Project.DAL.UnitOfWork;
using Project.DAL;
using Project.BL.Mappers;
using Project.Common.Enum;
using Project.DAL.Entities;


namespace Project.BL.Tests;

public class ActivityFacadeTests : FacadeTestsBase
{
    private IActivityFacade _activityFacadeSUT;
    public ActivityFacadeTests(ITestOutputHelper output) : base(output)
    {
        _activityFacadeSUT = new ActivityFacade(UnitOfWorkFactory, ActivityModelMapper);
    }

    [Fact]
    public async Task Create_newDetailItem()
    {
        var subjectId = Guid.NewGuid();
        var model = new ActivityDetailModel()
        {
            SubjectName = "English",
            Code = "Eng",
            Duration = TimeSpan.FromHours(1),

            ActivityStartTime = DateTime.Now,
            ActivityEndTime = DateTime.Now.AddHours(1),

            Description = "Example description",
            ActivityType = Tag.Lecture, 
            ActivityWeekDay = DayOfWeek.Monday, 

            
            ActivityRoom = LectureRoom.D105,
             
        };


        await Assert.ThrowsAnyAsync<InvalidOperationException>(() => _activityFacadeSUT.SaveAsync(model, subjectId));

    }

    [Fact]
    public async Task Create_newListItem()
    {
        var subjectId = Guid.NewGuid();
        var model = new ActivityListModel()
        {
            SubjectName = "Mathematics",
            Code = "MATH101",
            Duration = TimeSpan.FromHours(1),

            ActivityStartTime = DateTime.Now,
            ActivityEndTime = DateTime.Now.AddHours(1),

            ActivityType = Tag.Lecture,
            ActivityWeekDay = DayOfWeek.Monday,

            ActivityRoom = LectureRoom.D105,
            
        };

        await Assert.ThrowsAnyAsync<InvalidOperationException>(() => _activityFacadeSUT.SaveAsync(model, subjectId));
    }
    
    /*[Fact]
    public async Task GetAsync_ShouldReturnListOfModels()
    {
        
        var entity = new ActivityEntity
        {
            Id = Guid.NewGuid(),
            Start = DateTime.Now,
            End = DateTime.Now.AddHours(1),
            LectureRoom = LectureRoom.D105,
            Tag = Tag.Lecture,
            SubjectId = Guid.Parse("87833e49-67a5-4d6b-930b-fe54b488dbd8"),
            Description = "Example description",
            Subject = ActivitySeeds.FirstLecture.Subject,
            Grades = Array.Empty<GradeEntity>()
        };

        var model = ActivityModelMapper.MapToListModel(entity);
            
        var result = await _activityFacadeSUT.GetAsync();
        
        Assert.NotNull(result);
        Assert.Equal(model, result);
    }#1#
    
    
    
}
*/
