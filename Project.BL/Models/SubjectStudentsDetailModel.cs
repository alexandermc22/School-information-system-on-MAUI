namespace Project.BL.Models;

public record SubjectStudentsDetailModel: ModelBase
{
    public required Guid StudentId { get; set; }
    public required string StudentFirstName { get; set; }
    public required string StudentLastName { get; set; }
    public required Uri? StudentPhoto { get; set; }
    
    public static SubjectStudentsDetailModel Empty => new ()
    {
        Id = Guid.NewGuid(),
        StudentId = Guid.Empty,
        StudentFirstName = string.Empty,
        StudentLastName = string.Empty,
        StudentPhoto = null
    };
}