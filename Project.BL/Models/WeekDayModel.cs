using System.Collections.ObjectModel;
namespace Project.BL.Models;

public record class  WeekDayModel: ModelBase
{
    public required DateTime WeekDayDate { get; set; }
    public ObservableCollection<ActivityScheduleModel> Activities { get; init; } = new();

    public static WeekDayModel Empty => new()
    {
        Id = Guid.NewGuid(),
        WeekDayDate = DateTime.MinValue

    };

}