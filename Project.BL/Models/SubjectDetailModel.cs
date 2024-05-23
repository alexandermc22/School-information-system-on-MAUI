using System.Collections.ObjectModel;
namespace Project.BL.Models;

public record SubjectDetailModel : ModelBase
{
    
    public required string Name { get; set; }
    public required string Code { get; set; }

    public  Uri? ImageUrl { get; set; } 
    public ObservableCollection<SubjectStudentsListModel> SubjectStudents { get; set; } = new();
    public static SubjectDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty,
        Code = string.Empty,
    };
}