namespace Project.DAL.Entities;

public class SubjectEntity : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
        
    public required ICollection<ActionEntity> Actions { get; set; }

    public ICollection<StudentSubjectEntity> Students = new List<StudentSubjectEntity>();
}