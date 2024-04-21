using Project.Common.Enum;
namespace Project.DAL.Entities;

public class GradeEntity : IEntity
{
    public required Guid Id { get; set; }
    public required Grade GradeValue { get; set; }
    public string? Description { get; set; }
    
    public required DateTime GradeDate { get; set; }
    
    public required Guid ActivityId { get; set; }
    public required Guid StudentId { get; set; }
    public required ActivityEntity Activity { get; set; }
    public required StudentEntity Student { get; set; }
}