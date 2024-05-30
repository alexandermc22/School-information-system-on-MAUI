// using Microsoft.EntityFrameworkCore;
// using Project.DAL.Entities;
//
// namespace Project.DAL.Seeds;
//
// public static class StudentSeeds
// {
//     public static readonly StudentEntity Student1 = new()
//     {
//         Id = new Guid(),
//         FirstName = "John",
//         LastName = "Doe",
//         Photo = null,
//         StudentSubject = new List<StudentSubjectEntity>(),
//         Grades = new List<GradeEntity>()
//     };
//
//     public static readonly StudentEntity Student2 = new()
//     {
//         Id = new Guid(),
//         FirstName = "Jane",
//         LastName = "Doe",
//         Photo = null,
//         StudentSubject = new List<StudentSubjectEntity>(),
//         Grades = new List<GradeEntity>()
//     };
//
//     static StudentSeeds()
//     {
//         Student1.StudentSubject.Add(StudentSubjectSeeds.Student1Math);
//         Student2.StudentSubject.Add(StudentSubjectSeeds.Student2English);
//     }
//     
//     public static void Seed(this ModelBuilder modelBuilder) =>
//         modelBuilder.Entity<StudentEntity>().HasData(
//             Student1,
//             Student2
//         );
// }