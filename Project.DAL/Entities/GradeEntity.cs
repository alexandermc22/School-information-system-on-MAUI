namespace Project.DAL.Entities;

public class GradeEntity : IEntity
{
    public Guid Id { get; set; }
    public required double Score { get; set; }
    public string? Description { get; set; }
        
    public Guid IdAction { get; set; }
    public Guid IdStudent { get; set; }
    public required ActionEntity Action { get; set; }
    public required StudentEntity Student { get; set; }
}