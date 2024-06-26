
using Project.Common.Enum;
namespace Project.BL.Models;

public record class GradeDetailModel: ModelBase
{
    public required Guid StudentId { get; set; }
    
    public required  string StudentName { get; set; }
    public required Guid ActivityId { get; set; }
    public required Grade GradeValue { get; set; }
	public required string? Description { get; set; }
    public required DateTime GradeDate { get; set; }

    public static GradeDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        StudentId = Guid.Empty,
        StudentName = string.Empty,
        ActivityId = Guid.Empty,
        Description = string.Empty,
        GradeValue = Grade.None,
        GradeDate = DateTime.MinValue
    };


}