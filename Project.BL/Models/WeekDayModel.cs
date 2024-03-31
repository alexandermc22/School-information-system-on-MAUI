namespace Project.BL.Model;

public class WeekDayModel: ModelBase
{
    public required DateTime WeekDayDate { get; set; }
    public ObservableCollection<ActivityScheduleModel> Activities { get; init; } = new();
    
    public static WeekDayModel Empty => new()
    {
        Id = Guid.NewGuid(),
        WeekDayDate = DateTime.MinValue
            
    }
    
}