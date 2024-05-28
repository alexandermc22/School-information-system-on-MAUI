using System.Collections.ObjectModel;

namespace Project.BL.Models;

public record StudentDetailModel: ModelBase
{
    
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public  string? Photo { get; set; }
    public ObservableCollection<StudentSubjectsListModel> StudentSubjects { get; set; } = new();
    public static StudentDetailModel Empty => new()
    {
        Id = Guid.Empty,
        FirstName = string.Empty,
        LastName = string.Empty,
        Photo = null
    };
}