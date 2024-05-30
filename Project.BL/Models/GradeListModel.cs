using Project.Common.Enum;
namespace Project.BL.Models;
public record class GradeListModel : ModelBase
{
    public required Grade GradeValue { get; set; }
    
    public required Guid ActivityId { get; set; }
    
    public required Guid StudentId { get; set; }
    public required  string StudentName { get; set; }
    public required string? Description { get; set; }

    public required DateTime GradeDate { get; set; }

    public static GradeListModel Empty => new()
    {
        ActivityId = Guid.Empty,
        StudentId = Guid.Empty,
        Id = Guid.NewGuid(),
        Description = string.Empty,
        GradeValue = Grade.None,
        GradeDate = new DateTime(),
        StudentName = string.Empty
    };
}