using System.Collections.ObjectModel;

namespace Project.BL.Models;

public record StudentDetailModel: ModelBase
{
    public ObservableCollection<SubjectListModel> Subjects { get; set; } = new();
    public static StudentDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
    };
}