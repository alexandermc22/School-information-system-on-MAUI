using Project.Common.Enum;
namespace Project.BL.Models;

public record class GradeDetailModel: ModelBase
{
    public required Guid GradeId { get; set; }
    public required Guid SubjectId { get; set; }
    public required string SubjectCode { get; set; }
    public required Guid ActivityId { get; set; }
    public required Mark MarkValue { get; set; }
    public required DateTime GradeDate { get; set; }

    public static GradeDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        GradeId = Guid.Empty,
        SubjectId = Guid.Empty,
        SubjectCode = string.Empty,
        ActivityId = Guid.Empty,
        MarkValue = Mark.None,
        GradeDate = DateTime.MinValue
    };


}