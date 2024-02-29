namespace Project.DAL.Entities;

public class StudentSubjectEntity : IEntity
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid SubjectId { get; set; }
    public required StudentEntity Student { get; set; }
    public required SubjectEntity Subject { get; set; }
        
}