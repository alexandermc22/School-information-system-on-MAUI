namespace Project.BL.Models;

public record StudentSubjectsListModel: ModelBase
{
    public required Guid SubjectId { get; set; }
    public required string SubjectName { get; set; }
    public required string SubjectCode { get; set; }
    
    public static StudentSubjectsListModel Empty => new ()
    {
        Id = Guid.NewGuid(),
        SubjectId = Guid.Empty,
        SubjectName = string.Empty,
        SubjectCode = string.Empty
    };
}