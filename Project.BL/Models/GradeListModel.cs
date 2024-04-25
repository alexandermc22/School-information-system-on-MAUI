using Project.Common.Enum;
namespace Project.BL.Models;
public record class GradeListModel : ModelBase
{
    public required Mark MarkValue { get; set; }
    public required string SubjectName { get; set; }
    public required DateTime GradeDate { get; set; }

    public static GradeListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        MarkValue = Mark.None,
        SubjectName = string.Empty,
        GradeDate = new DateTime()
    };
}