using Project.BL.Models;
using Project.DAL.Entities;

namespace Project.BL.Mappers;

public interface IGradeModelMapper : IModelMapper<GradeEntity,GradeDetailModel,GradeListModel>
{
    public GradeListModel MapToListModel(GradeDetailModel detail);
    public GradeEntity MapToEntity(GradeDetailModel model, Guid studentId);
}