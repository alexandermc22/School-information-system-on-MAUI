namespace Project.DAL.Entities;

public record SubjectEntity : IEntity
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }

    public required Uri? ImageUrl { get; set; } 

    public ICollection<ActivityEntity> Activity { get; init; } = new List<ActivityEntity>();
    
    public ICollection<StudentSubjectEntity> StudentSubject  { get; init; } = new List<StudentSubjectEntity>();
}