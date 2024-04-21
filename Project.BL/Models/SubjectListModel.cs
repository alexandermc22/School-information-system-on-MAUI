namespace Project.BL.Models;

public record class SubjectListModel: ModelBase
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public string? ImageUrl { get; set; } 

    public static SubjectListModel Empty => new ()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty,
        Code = string.Empty
    };
    
    
}