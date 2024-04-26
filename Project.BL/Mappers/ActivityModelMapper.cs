using Project.BL.Models;
using Project.DAL.Entities;
namespace Project.BL.Mappers;

public  class ActivityModelMapper(GradeModelMapper gradeModelMapper) : 
    ModelMapperBase<ActivityEntity,ActivityDetailModel,ActivityListModel>
{

    public override ActivityListModel MapToListModel(ActivityEntity? entity)
        => entity?.Subject is null
            ? ActivityListModel.Empty
            : new ActivityListModel
            {
                Id = entity.Id,
                SubjectName = entity.Subject.Name,
                Code = entity.Subject.Code,
                Duration = entity.End - entity.Start,
                ActivityStartTime = entity.Start,
                ActivityEndTime = entity.End,
                ActivityType = entity.Tag,
                ActivityWeekDay = entity.Start.DayOfWeek,
                ActivityRoom = entity.LectureRoom
            };
    
    public  ActivityListModel MapToListModel(ActivityDetailModel detail)
        => new ActivityListModel
            {
                Id = detail.Id,
                SubjectName = detail.SubjectName,
                Code = detail.Code,
                Duration = detail.Duration,
                ActivityStartTime = detail.ActivityStartTime,
                ActivityEndTime = detail.ActivityEndTime,
                ActivityType = detail.ActivityType,
                ActivityWeekDay = detail.ActivityWeekDay,
                ActivityRoom = detail.ActivityRoom
            };
    
    // maybe unused
    public void MapToExistingDetailModel(ActivityDetailModel existingDetailModel,
        SubjectListModel subject)
    {
        existingDetailModel.SubjectName = subject.Name;
    }

    public override ActivityDetailModel MapToDetailModel(ActivityEntity? entity)
        => entity?.Subject is null
            ? ActivityDetailModel.Empty
            : new ActivityDetailModel
            {
                Id = entity.Id,
                SubjectName = entity.Subject.Name,
                Code = entity.Subject.Code,
                Duration = entity.End - entity.Start,
                ActivityStartTime = entity.Start,
                ActivityEndTime = entity.End,
                ActivityType = entity.Tag,
                ActivityWeekDay = entity.Start.DayOfWeek,
                ActivityRoom = entity.LectureRoom,
                Description = entity.Description,
                Grades = gradeModelMapper.MapToListModel(entity.Grades).ToObservableCollection()
            };
    
    public override ActivityEntity MapToEntity(ActivityDetailModel model)
        => throw new NotImplementedException("This method is unsupported. Use the other overload.");

    
    public ActivityEntity MapToEntity(ActivityDetailModel model, Guid subjectId)
        => new()
        {
            Id = model.Id,
            Start = model.ActivityStartTime,
            End = model.ActivityEndTime,
            LectureRoom = model.ActivityRoom,
            Tag = model.ActivityType,
            SubjectId = subjectId,
            Description = model.Description,
            Subject = null!,
            Grades = null!
        };
    public ActivityEntity MapToEntity(ActivityListModel model, Guid subjectId)
        => new()
        {
            Id = model.Id,
            Start = model.ActivityStartTime,
            End = model.ActivityEndTime,
            LectureRoom = model.ActivityRoom,
            Tag = model.ActivityType,
            SubjectId = subjectId,
            Description = null,
            Subject = null!,
            Grades = null!
        };

}