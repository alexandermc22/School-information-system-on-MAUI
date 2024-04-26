namespace Project.DAL.Entities;

public record SubjectEntity : IEntity
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }

    public required Uri? ImageUrl { get; set; } 

    public ICollection<ActivityEntity> Activity { get; set; } = new List<ActivityEntity>();
    
    public ICollection<StudentSubjectEntity> StudentSubject  { get; set; } = new List<StudentSubjectEntity>();
}