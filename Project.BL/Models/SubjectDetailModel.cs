using System.Collections.ObjectModel;
namespace Project.BL.Models;

public record SubjectDetailModel : ModelBase
{
    public ObservableCollection<StudentListModel> Students { get; set; } = new();
    public static SubjectDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
    };
}