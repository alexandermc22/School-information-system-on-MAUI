namespace Project.DAL.Entities;

public class SubjectEntity : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
        
    public required ICollection<ActionEntity> Subjects { get; set; }

    public ICollection<StudentSubjectEntity> StudentSubjects = new List<StudentSubjectEntity>();
}