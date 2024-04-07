using Microsoft.EntityFrameworkCore;
using Project.Common.Enum;
using Project.DAL.Entities;
using Project.DAL.Seeds;

namespace Project.Common.Tests.Seeds;

public static class GradeSeeds
{
    public static readonly GradeEntity Grade1 = new()
    {
        Id = Guid.Parse("85533e48-67a4-455b-910b-fe59998dbd8"),
        GradeValue = Grade.A,
        Description = "Excellent work!",
        GradeDate = DateTime.Now.AddDays(-7),
        Student = StudentSeeds.Student1,
        Activity = ActivitySeeds.FirstLecture,
        ActivityId = Guid.Parse("85343e48-67a4-055b-910b-fe537388dbd8"),
        StudentId = Guid.Parse("87833e45-67ji-4d6b-930b-fe54ki88dbd8")
    };
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<GradeEntity>().HasData(
            Grade1
        );
}