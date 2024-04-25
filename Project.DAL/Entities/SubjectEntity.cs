namespace Project.DAL.Entities;

public record SubjectEntity : IEntity
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
    
    public string? ImageUrl { get; set; }

    public ICollection<ActivityEntity> Actions { get; set; } = new List<ActivityEntity>();
    
    public ICollection<StudentSubjectEntity> StudentSubject  { get; set; } = new List<StudentSubjectEntity>();
}