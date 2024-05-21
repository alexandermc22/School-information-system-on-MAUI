using Project.Common.Enum;
namespace Project.DAL.Entities;

public record ActivityEntity : IEntity
{
    public required Guid Id { get; set; }
    public required DateTime Start { get; set; }
    public required DateTime End { get; set; }
    public required LectureRoom LectureRoom { get; set; }
    public required Tag Tag { get; set; }
    public required Guid SubjectId { get; set; }
    public required string? Description { get; set; }
    public required SubjectEntity Subject { get; set; }
    public ICollection<GradeEntity> Grades { get; init; } = new List<GradeEntity>();


}
