using Project.BL.Models;
using Project.DAL.Entities;

namespace Project.BL.Mappers;

public class GradeModelMapper :
    ModelMapperBase<GradeEntity, GradeDetailModel, GradeListModel>, IGradeModelMapper
{
    public override GradeListModel MapToListModel(GradeEntity? entity)
        => entity is null
            ? GradeListModel.Empty
            : new GradeListModel
            {
                StudentName = $"{entity.Student.FirstName} {entity.Student.LastName}",
                GradeValue = entity.GradeValue,
                SubjectName = entity.Activity.Subject.Name, // TODO check if subj != null
                GradeDate = entity.GradeDate
            };

    public GradeListModel MapToListModel(GradeDetailModel detail)
        => new GradeListModel
        {
            StudentName = detail.StudentName,
            GradeValue = detail.GradeValue,
            SubjectName = detail.SubjectName,
            GradeDate = detail.GradeDate
        };

    // public IEnumerable<GradeListModel> MapToListModel(IEnumerable<GradeEntity> entities)
    //     => entities.Select(MapToListModel);

    public override GradeDetailModel MapToDetailModel(GradeEntity? entity)
    {
        if (entity is null)
        {
            return GradeDetailModel.Empty;
        }
        else
        {
            return new GradeDetailModel
            {
                Id = entity.Id,
                StudentName = $"{entity.Student.FirstName} {entity.Student.LastName}",
                SubjectId = entity.Activity.SubjectId,
                SubjectName = entity.Activity.Subject.Name,
                ActivityId = entity.ActivityId,
                GradeValue = entity.GradeValue,
                GradeDate = entity.GradeDate,
                Description = entity.Description
            };
        }
    }

    public override GradeEntity MapToEntity(GradeDetailModel model)
        => throw new NotImplementedException("This method is unsupported. Use the other overload.");

    public GradeEntity MapToEntity(GradeDetailModel model, Guid studentId)
        => new()
        {
            Id = model.Id,
            GradeValue = model.GradeValue,
            Description = model.Description,
            GradeDate = model.GradeDate,
            ActivityId = model.ActivityId,
            StudentId = studentId,
            Activity = null!,
            Student = null!,
        };
}