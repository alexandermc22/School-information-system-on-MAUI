using Project.Common.Enum;

namespace Project.BL.Models;

public record class ActivityScheduleModel: ModelBase
{
    public required Guid ActivityId { get; set; }
    public required string SubjectName { get; set; }
    public required string Code { get; set; }
    public required TimeSpan Duration { get; set; }
    public required DateTime ActivityStartTime { get; set; }
    public required DateTime ActivityEndTime { get; set; }
    public Tag ActivityType { get; set; }
    public WeekDay ActivityWeekDay { get; set; }
    public LectureRoom ActivityRoom { get; set; }
    public Mark ActivityMark { get; set; }

    public static ActivityScheduleModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Code = string.Empty,
        ActivityId = Guid.Empty,
        SubjectName = string.Empty,
        Duration = TimeSpan.Zero,
        ActivityStartTime = DateTime.MinValue,
        ActivityEndTime = DateTime.MinValue,


    };


}