using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Project.DAL.Entities;

namespace Project.Common.Tests.Seeds;

public static class SubjectSeeds
{
    public static readonly SubjectEntity Math = new()
    {
        Id = Guid.Parse("87833e49-67a5-4d6b-930b-fe54b488dbd8"),
        Name = "Mathematics",
        Code = "MATH101",
        ImageUrl = new Uri("https://example.com/mathematics_image.jpg"),
    };
    
    public static readonly SubjectEntity English = new()
    {
        Id = Guid.Parse("88833e49-67a5-4d6b-930b-fe54b488dbd8"),
        Name = "English",
        Code = "ENG101",
        ImageUrl = new Uri("https://example.com/english_image.jpg"),
    };

    static SubjectSeeds()
    {
        //Math.Activity.Add(ActivitySeeds.FirstLecture);
        //Math.StudentSubject.Add(StudentSubjectSeeds.Student1Math);
        //Math.StudentSubject.Add(StudentSubjectSeeds.Student2English);
    }

    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<SubjectEntity>().HasData(
            Math with { Activity = Array.Empty<ActivityEntity>(), StudentSubject = Array.Empty<StudentSubjectEntity>()},
            English with { Activity = Array.Empty<ActivityEntity>(), StudentSubject = Array.Empty<StudentSubjectEntity>() }
        );
}