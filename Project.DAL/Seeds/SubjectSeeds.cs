// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
// using Project.DAL.Entities;
//
// namespace Project.DAL.Seeds;
//
// public static class SubjectSeeds
// {
//     public static readonly SubjectEntity Math = new()
//     {
//         Id = new Guid(),
//         Name = "Mathematics",
//         Code = "MATH101",
//         ImageUrl = null,
//         Activity = new List<ActivityEntity>(),
//         StudentSubject = new List<StudentSubjectEntity>()
//     };
//     
//     public static readonly SubjectEntity English = new()
//     {
//         Id = new Guid(),
//         Name = "English",
//         Code = "ENG101",
//         ImageUrl = null,
//         Activity = new List<ActivityEntity>(),
//         StudentSubject = new List<StudentSubjectEntity>()
//     };
//
//     static SubjectSeeds()
//     {
//         Math.StudentSubject.Add(StudentSubjectSeeds.Student1Math);
//         Math.StudentSubject.Add(StudentSubjectSeeds.Student2English);
//         Math.Activity.Add(ActivitySeeds.FirstLecture);
//     }
//
//     public static void Seed(this ModelBuilder modelBuilder) =>
//         modelBuilder.Entity<SubjectEntity>().HasData(
//             Math,
//             English
//         );
// }