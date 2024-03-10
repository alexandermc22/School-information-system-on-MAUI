namespace Project.DAL.Entities;

public class GradeEntity : IEntity
{
    public required Guid Id { get; set; }
    public required double Score { get; set; }
    public string? Description { get; set; }
        
    public required Guid IdAction { get; set; }
    public required Guid IdStudent { get; set; }
    public required ActionEntity Action { get; set; }
    public required StudentEntity Student { get; set; }
}