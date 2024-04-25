
using Project.Common.Enum;
namespace Project.BL.Models;

public record class GradeDetailModel: ModelBase
{
    public required Guid SubjectId { get; set; }
    public required string SubjectName { get; set; }
    public required Guid ActivityId { get; set; }
    public required Mark MarkValue { get; set; }
	public required string Description { get; set; }
    public required DateTime GradeDate { get; set; }

    public static GradeDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        SubjectId = Guid.Empty,
        SubjectName = string.Empty,
        ActivityId = Guid.Empty,
        Description = string.Empty,
        MarkValue = Mark.None,
        GradeDate = DateTime.MinValue
    };


}