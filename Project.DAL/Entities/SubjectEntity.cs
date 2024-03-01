namespace Project.DAL.Entities;

public class SubjectEntity : IEntity
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }

    public ICollection<ActionEntity> Actions { get; set; } = new List<ActionEntity>();

    public ICollection<StudentSubjectEntity> Students  { get; set; } = new List<StudentSubjectEntity>();
}