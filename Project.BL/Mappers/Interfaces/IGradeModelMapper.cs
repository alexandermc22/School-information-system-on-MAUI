using Project.BL.Models;
using Project.DAL.Entities;

namespace Project.BL.Mappers;

public interface IGradeModelMapper : IModelMapper<GradeEntity,GradeDetailModel,GradeListModel>
{
    public GradeListModel MapToListModel(GradeDetailModel detail);
    public GradeEntity MapToEntity(GradeDetailModel model, Guid studentId);
    public GradeEntity MapToEntity(GradeListModel model, Guid activityId);

    public void MapToExistingDetailModel(GradeDetailModel existingDetailModel,
        StudentListModel student);
}