namespace Project.BL.Models;

public record class StudentListModel: ModelBase
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Photo { get; set; }

    public static StudentListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        FirstName = string.Empty,
        LastName = string.Empty
    };
}