using Project.BL.Models;
using Project.DAL.Entities;
namespace Project.BL.Mappers;

public class GradeListDetailModelMapper: 
    ModelMapperListDetailBase<GradeEntity,GradeDetailModel,GradeListModel>
{
    
    public override GradeListModel MapToListModel(GradeEntity? entity)
        => entity is null
            ? GradeListModel.Empty
            : new GradeListModel
            {
                GradeValue = entity.GradeValue
            };
    public  GradeListModel MapToListModel(GradeDetailModel detail)
        =>  new GradeListModel
            {
                GradeValue = detail.GradeValue
            };

    public IEnumerable<GradeListModel> MapToListModel(IEnumerable<GradeEntity> entities)
        => entities.Select(MapToListModel);

    public override GradeDetailModel MapToDetailModel(GradeEntity? entity)
    {
        if (entity?.Activity is null)
        {
            return GradeDetailModel.Empty;
        }
        else
        {
            if (entity?.Activity.Subject is null)
            {
                return new GradeDetailModel
                {
                    Id = entity.Id,
                    SubjectId = Guid.Empty,
                    SubjectCode = string.Empty,
                    ActivityId = entity.ActivityId,
                    GradeValue = entity.GradeValue,
                    GradeDate = entity.GradeDate,
                    Description = entity.Description,
                };
            }
            else
            {
                return new GradeDetailModel
                {
                    Id = entity.Id,
                    SubjectId = entity.Activity.SubjectId,
                    SubjectCode = entity.Activity.Subject.Code,
                    ActivityId = entity.ActivityId,
                    GradeValue = entity.GradeValue,
                    GradeDate = entity.GradeDate,
                    Description = entity.Description
                };
            }
        }
    }

    public override GradeEntity MapToEntity(GradeDetailModel model)
        => throw new NotImplementedException("This method is unsupported. Use the other overload.");

    public GradeEntity MapToEntity(GradeDetailModel model, Guid StudentId)
        => new()
        {
            Id = model.Id,
            GradeValue = model.GradeValue,
            Description = model.Description,
            GradeDate = model.GradeDate,
            ActivityId = model.ActivityId,
            StudentId = StudentId,
            Activity = null!,
            Student = null!,
        };
}