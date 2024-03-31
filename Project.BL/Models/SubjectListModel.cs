namespace Project.BL.Model;

public class SubjectListModel: ModelBase
{
    public required Guid SubjectId { get; set }
    public required string Name { get; set }
    public string? ImageUrl { get; set }

    public static SubjectListModel => new ()
    {
        Id = Guid.NewGuid(),
        SubjectId = Guid.Empty,    
        Name = string.Empty    
    };
    
    
}