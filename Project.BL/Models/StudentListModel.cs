namespace Project.BL.Models;

public record class StudentListModel: ModelBase
{
    public required Guid StudentId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Photo { get; set; }

    public static StudentListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        StudentId = Guid.Empty,
        FirstName = string.Empty,
        LastName = string.Empty
    };
}