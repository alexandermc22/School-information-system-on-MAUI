namespace Project.DAL.Entities;

public record StudentSubjectEntity : IEntity
{
    public required Guid Id { get; set; }
    public required Guid StudentId { get; set; }
    public required Guid SubjectId { get; set; }
    public required StudentEntity Student { get; set; }
    public required SubjectEntity Subject { get; set; }
        
}