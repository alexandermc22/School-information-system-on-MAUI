namespace Project.DAL.Entities;

public class GradeEntity : IEntity
{
    public required Guid Id { get; set; }
    public required double Score { get; set; }
    public string? Description { get; set; }
        
    public required Guid ActionId { get; set; }
    public required Guid StudentId { get; set; }
    public required ActionEntity Action { get; set; }
    public required StudentEntity Student { get; set; }
}