using Project.BL.Models;
using Project.DAL.Entities;

namespace Project.BL.Mappers;

public interface IActivityModelMapper :IModelMapper<ActivityEntity,ActivityDetailModel,ActivityListModel>
{
    public ActivityListModel MapToListModel(ActivityDetailModel detail);
    public ActivityEntity MapToEntity(ActivityDetailModel model, Guid subjectId);
    public ActivityEntity MapToEntity(ActivityListModel model, Guid subjectId);
}