using Project.Common.Enum;

namespace Project.BL.Models;

public record class ActivityListModel: ModelBase
{
    public required string SubjectName { get; set; }
    public required string Code { get; set; }
    public required TimeSpan Duration { get; set; }
    public required DateTime ActivityStartTime { get; set; }
    public required DateTime ActivityEndTime { get; set; }
    public Tag ActivityType { get; set; }
    public DayOfWeek ActivityWeekDay { get; set; }
    public LectureRoom ActivityRoom { get; set; }
    public Mark ActivityMark { get; set; } // зачем оценка?

    public static ActivityListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Code = string.Empty,
        SubjectName = string.Empty,
        Duration = TimeSpan.Zero,
        ActivityStartTime = DateTime.MinValue,
        ActivityEndTime = DateTime.MinValue,


    };


}