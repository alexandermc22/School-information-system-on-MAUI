using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;

namespace Project.DAL.Seeds;

public static class StudentSeeds
{
    public static readonly StudentEntity Student1 = new()
    {
        Id = Guid.Parse("87833e45-67ji-4d6b-930b-fe54ki88dbd8"),
        FirstName = "John",
        LastName = "Doe",
        Photo = "https://example.com/john_doe_photo.jpg",
        StudentSubject = new List<StudentSubjectEntity>()
    };

    public static readonly StudentEntity Student2 = new()
    {
        Id = Guid.Parse("99833e45-67ji-4d6b-930b-fe54ki88dbd8"),
        FirstName = "Jane",
        LastName = "Doe",
        Photo = "https://example.com/jane_doe_photo.jpg",
        StudentSubject = new List<StudentSubjectEntity>() 
    };

    static StudentSeeds()
    {
        Student1.StudentSubject.Add(StudentSubjectSeeds.Student1Math);
        Student2.StudentSubject.Add(StudentSubjectSeeds.Student2English);
    }
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<StudentEntity>().HasData(
            Student1,
            Student2
        );
}