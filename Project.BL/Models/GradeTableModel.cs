namespace Project.BL.Model;

public class MarkTableModel
{
    public required Mark MarkValue { get; set }
   
    public static MarkTableModel Empty = new ()
    {
        Id = Guid.NewGuid(),
        Mark = Mark.F
    }
}