namespace Project.BL.Models;

public record class SubjectListModel: ModelBase
{
    public required Guid SubjectId { get; set; }
    public required string Name { get; set; }
    public string? ImageUrl { get; set; }

    public static SubjectListModel Empty => new ()
    {
        Id = Guid.NewGuid(),
        SubjectId = Guid.Empty,    
        Name = string.Empty    
    };
    
    
}