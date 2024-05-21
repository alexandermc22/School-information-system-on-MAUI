using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using SQLitePCL;

namespace Project.Common.Tests.Seeds;

public static class StudentSeeds
{
    public static readonly StudentEntity EmptyStudent = new()
    {
        Id = default,
        FirstName = default!,
        LastName = default!,
        Photo = default,
        StudentSubject = default!
    };
    
    public static readonly StudentEntity Student1 = new()
    {
        Id = Guid.Parse("87833e45-67aa-4d6b-930b-fe54aa88dbd8"),
        FirstName = "John",
        LastName = "Doe",
        Photo = new Uri("https://example.com/john_doe_photo.jpg"),
    };

    public static readonly StudentEntity Student2 = new()
    {
        Id = Guid.Parse("99833e45-67aa-4d6b-930b-fe54aa88dbd8"),
        FirstName = "Jane",
        LastName = "Doe",
        Photo = new Uri("https://example.com/jane_doe_photo.jpg"),
    };

    static StudentSeeds()
    {
        Student1.StudentSubject.Add(StudentSubjectSeeds.Student1Math);
        Student2.StudentSubject.Add(StudentSubjectSeeds.Student2English);
    }
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<StudentEntity>().HasData(
            Student1 with { StudentSubject = Array.Empty<StudentSubjectEntity>() },
            Student2 with { StudentSubject = Array.Empty<StudentSubjectEntity>() }
        );
}