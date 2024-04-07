using Project.BL.Models;

namespace Project.BL.Facades;

public interface IActivityFacade
{
    Task SaveAsync(ActivityDetailModel model, Guid subjectId);
    Task SaveAsync(ActivityListModel model, Guid subjectId);
    Task DeleteAsync(Guid id);
}