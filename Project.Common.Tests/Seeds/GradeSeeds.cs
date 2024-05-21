using Microsoft.EntityFrameworkCore;
using Project.Common.Enum;
using Project.DAL.Entities;
using Project.DAL.Seeds;

namespace Project.Common.Tests.Seeds;

public static class GradeSeeds
{
    public static readonly GradeEntity EmptyGrade = new()
    {
        Id = default,
        GradeValue = default,
        Description = default,
        GradeDate = default,
        Student = default!,
        Activity = default!,
        ActivityId = default,
        StudentId = default
    };
    public static readonly GradeEntity Grade1 = new()
    {
        Id = Guid.Parse("85533e48-67a4-455b-910b-fe59998dbd80"),
        GradeValue = Grade.A,
        Description = "Excellent work!",
        GradeDate = DateTime.Now.AddDays(-7),
        ActivityId = ActivitySeeds.FirstLecture.Id,
        StudentId = StudentSeeds.Student1.Id,
        Student = StudentSeeds.Student1,
        Activity = ActivitySeeds.FirstLecture
    };
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<GradeEntity>().HasData(
            Grade1 with { Student = null!, Activity = null! }
        );
}