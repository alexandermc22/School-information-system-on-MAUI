using Project.BL.Models;
using Project.DAL.Entities;

namespace Project.BL.Facades;

public interface IActivityFacade : IFacade<ActivityEntity, ActivityListModel , ActivityDetailModel>
{
    Task<IEnumerable<ActivityListModel>?> GetActivityAsync(Guid id);
    Task SaveAsync(ActivityDetailModel model, Guid subjectId);
    Task SaveAsync(ActivityListModel model, Guid subjectId);

    Task<IEnumerable<ActivityListModel>?> GetFilteredAsync(Guid subjectId, DateTime activityStartTime,
        DateTime activityEndTime);
    // Task DeleteAsync(Guid id);
}