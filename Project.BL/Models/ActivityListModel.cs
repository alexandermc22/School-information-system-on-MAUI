using Project.Common.Enum;

namespace Project.BL.Models;

public record class ActivityListModel: ModelBase
{
    public  string SubjectName { get; set; }
    public  string Code { get; set; }
    public required TimeSpan Duration { get; set; }
    public required DateTime ActivityStartTime { get; set; }
    public required DateTime ActivityEndTime { get; set; }
    public required string ActivityType { get; set; }
    public DayOfWeek ActivityWeekDay { get; set; }
    public required string ActivityRoom { get; set; }

    public static ActivityListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Code = string.Empty,
        SubjectName = string.Empty,
        ActivityType = string.Empty,
        Duration = TimeSpan.Zero,
        ActivityStartTime = DateTime.MinValue,
        ActivityEndTime = DateTime.MinValue,
        ActivityRoom = string.Empty

    };


}