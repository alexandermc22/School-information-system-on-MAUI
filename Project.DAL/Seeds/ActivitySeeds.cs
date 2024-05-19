// using Microsoft.EntityFrameworkCore;
// using Project.DAL.Entities;
// using Project.DAL.Seeds;
//
// namespace Project.DAL;
//
// using Project.Common.Enum;
// public static class ActivitySeeds
// {
//     public static readonly ActivityEntity FirstLecture = new()
//     {
//         Id = new Guid(),
//         Start = DateTime.Now.AddDays(1), // Example start time
//         End = DateTime.Now.AddDays(1).AddHours(2), // Example end time
//         LectureRoom = LectureRoom.D105,
//         Tag = Tag.Lecture,
//         SubjectId = Guid.Parse("87833e49-67a5-4d6b-930b-fe54b488dbd8"),
//         Grades = new List<GradeEntity>(),
//         Description = "Example description",
//         Subject = SubjectSeeds.Math,
//     };
//     
//     static ActivitySeeds()
//     {
//         // Добавляем объект Grade1 из GradeSeeds в список Grades
//         FirstLecture.Grades.Add(GradeSeeds.Grade1);
//     }
//         
//     public static void Seed(this ModelBuilder modelBuilder) =>
//         modelBuilder.Entity<ActivityEntity>().HasData(
//             FirstLecture
//         );
// }