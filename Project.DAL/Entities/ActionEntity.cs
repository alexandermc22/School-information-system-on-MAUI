namespace Project.DAL.Entities;

public class ActionEntity : IEntity
{
    public Guid Id { get; set; }
    public required DateTime Start { get; set; }
    public required DateTime End { get; set; }
    public required Enum LectureRoom { get; set; }
    public required Enum Tag { get; set; }
    public required string Description { get; set; }
        
    public required Guid SubjectId { get; set; }
    public required SubjectEntity Subject { get; set; }
        
    public required ICollection<GradeEntity> Grades { get; set; }
        
}