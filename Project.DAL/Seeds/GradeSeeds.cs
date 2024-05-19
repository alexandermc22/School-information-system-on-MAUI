// using Microsoft.EntityFrameworkCore;
// using Project.Common.Enum;
// using Project.DAL.Entities;
// using Project.DAL.Seeds;
//
// namespace Project.DAL;
//
// public static class GradeSeeds
// {
//     public static readonly GradeEntity Grade1 = new()
//     {
//         Id = new Guid(),
//         GradeValue = Grade.A,
//         Description = "Excellent work!",
//         GradeDate = DateTime.Now.AddDays(-7),
//         Student = StudentSeeds.Student1,
//         Activity = ActivitySeeds.FirstLecture,
//         ActivityId = new Guid(),
//         StudentId = new Guid(),
//     };
//     
//     public static void Seed(this ModelBuilder modelBuilder) =>
//         modelBuilder.Entity<GradeEntity>().HasData(
//             Grade1
//         );
// }