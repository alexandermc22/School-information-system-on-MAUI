using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using Project.Common.Enum;

namespace Project.Common.Tests.Seeds;

public static class ActivitySeeds
{
    public static readonly ActivityEntity EmptyActivity = new()
    {
        Id = default,
        Start = default,
        End = default,
        LectureRoom = default,
        Tag = default,
        SubjectId = default,
        Description = default,
        Subject = default!
    };
    public static readonly ActivityEntity FirstLecture = new()
    {
        Id = Guid.Parse("85343e48-67a4-055b-910b-fe537388dbd8"),
        Start = DateTime.Now.AddDays(1), // Example start time
        End = DateTime.Now.AddDays(1).AddHours(2), // Example end time
        LectureRoom = LectureRoom.D105,
        Tag = Tag.Lecture,
        SubjectId = SubjectSeeds.Math.Id,
        Description = "Example description",
        Subject = SubjectSeeds.Math
    };
    
    /*public static readonly ActivityEntity ActivityEntityWithNoGrades = FirstLecture with { Id = Guid.Parse("98B7F7B6-0F51-43B3-B8C0-B5FCFFF6DC2E"), Grades = Array.Empty<GradeEntity>() };
    public static readonly ActivityEntity ActivityEntityUpdate = FirstLecture with { Id = Guid.Parse("0953F3CE-7B1A-48C1-9796-D2BAC7F67868"), Grades = Array.Empty<GradeEntity>() };
    public static readonly ActivityEntity ActivityEntityDelete = FirstLecture with { Id = Guid.Parse("5DCA4CEA-B8A8-4C86-A0B3-FFB78FBA1A09"), Grades = Array.Empty<GradeEntity>() };

    public static readonly ActivityEntity ActivityForGradeEntityUpdate = FirstLecture with { Id = Guid.Parse("4FD824C0-A7D1-48BA-8E7C-4F136CF8BF31"), Grades = Array.Empty<GradeEntity>() };
    public static readonly ActivityEntity ActivityForGradeEntityDelete = FirstLecture with { Id = Guid.Parse("F78ED923-E094-4016-9045-3F5BB7F2EB88"), Grades = new List<GradeEntity>() };*/
    static ActivitySeeds()
    {
        // Добавляем объект Grade1 из GradeSeeds в список Grades
        FirstLecture.Grades.Add(GradeSeeds.Grade1);
    }
        
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<ActivityEntity>().HasData(
            FirstLecture with { Grades = Array.Empty<GradeEntity>() , Subject = null!}
            /*ActivityEntityWithNoGrades,
            ActivityEntityUpdate,
            ActivityEntityDelete,
            ActivityForGradeEntityUpdate,
            ActivityForGradeEntityDelete with { Grades = Array.Empty<GradeEntity>() }*/
        );
}