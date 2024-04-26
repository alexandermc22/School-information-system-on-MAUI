using Project.Common.Enum;
namespace Project.BL.Models;
public record class GradeListModel : ModelBase
{
    public required Grade GradeValue { get; set; }
    public required string SubjectName { get; set; }
    public required DateTime GradeDate { get; set; }

    public static GradeListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        GradeValue = Grade.None,
        SubjectName = string.Empty,
        GradeDate = new DateTime()
    };
}