namespace Project.BL.Models;

public record SubjectStudentsListModel : ModelBase
{
    public required Guid StudentId { get; set; }
    public required string StudentFirstName { get; set; }
    public required string StudentLastName { get; set; }
    
    public static SubjectStudentsListModel Empty => new ()
    {
        Id = Guid.NewGuid(),
        StudentId = Guid.Empty,
        StudentFirstName = string.Empty,
        StudentLastName = string.Empty
    };
}