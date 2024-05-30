// using Microsoft.EntityFrameworkCore;
// using Project.DAL.Entities;
//
// namespace Project.DAL.Seeds;
//
// public static class StudentSubjectSeeds
// {
//     public static readonly StudentSubjectEntity Student1Math = new()
//     {
//         Id = new Guid(),
//         StudentId = new Guid(),
//         SubjectId = new Guid(),
//         Student = StudentSeeds.Student1,
//         Subject = SubjectSeeds.Math
//     };
//     public static readonly StudentSubjectEntity Student2English = new()
//     {
//         Id = new Guid(),
//         StudentId = new Guid(),
//         SubjectId = new Guid(),
//         Student = StudentSeeds.Student2,
//         Subject = SubjectSeeds.English
//     };
//
//     public static void Seed(this ModelBuilder modelBuilder) =>
//         modelBuilder.Entity<StudentSubjectEntity>().HasData(
//             Student1Math,
//             Student2English
//         );
// }