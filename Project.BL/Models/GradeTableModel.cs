using Project.Common.Enum;
namespace Project.BL.Models;
public record class MarkTableModel : ModelBase
{
    public required Mark MarkValue { get; set; }

    public static MarkTableModel Empty => new()
    {
        Id = Guid.NewGuid(),
        MarkValue = Mark.None
    };
}