using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using SQLitePCL;

namespace Project.Common.Tests.Seeds;

public static class StudentSubjectSeeds
{
    public static readonly StudentSubjectEntity EmptyStudentSubject = new()
    {
        Id = default,
        StudentId = default,
        SubjectId = default,
        Student = default!,
        Subject = default!
    };
        
    public static readonly StudentSubjectEntity Student1Math = new()
    {
        Id = Guid.Parse("85533e48-67a4-4d6b-910b-fe537388dbd8"),
        StudentId = Guid.Parse("87833e47-67a3-4d6b-930b-fe54b488dbd8"),
        SubjectId = Guid.Parse("87833e49-67a5-4d6b-930b-fe54b488dbd8"),
        Student = StudentSeeds.Student1,
        Subject = SubjectSeeds.Math
    };
    public static readonly StudentSubjectEntity Student2English = new()
    {
        Id = Guid.Parse("85533e48-67a4-455b-910b-fe537388dbd8"),
        StudentId = Guid.Parse("99833e45-67aa-4d6b-930b-fe54aa88dbd8"),
        SubjectId = Guid.Parse("88833e49-67a5-4d6b-930b-fe54b488dbd8"),
        Student = StudentSeeds.Student2,
        Subject = SubjectSeeds.English
    };

    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<StudentSubjectEntity>().HasData(
            Student1Math with {Student = null!, Subject = null! },
            Student2English with {Student = null!, Subject = null! }
        );
}