namespace Project.BL.Models;

public record StudentSubjectsDetailModel : ModelBase
{
    public required Guid SubjectId { get; set; }
    public required string SubjectName { get; set; }
    public required string SubjectCode { get; set; }
    
    public required string? SubjectImageUrl { get; set; }
    
    public static StudentSubjectsDetailModel Empty => new ()
    {
        Id = Guid.NewGuid(),
        SubjectId = Guid.Empty,
        SubjectName = string.Empty,
        SubjectCode = string.Empty,
        SubjectImageUrl = null
    };
}