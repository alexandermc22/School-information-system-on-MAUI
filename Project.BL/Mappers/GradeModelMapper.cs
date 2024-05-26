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
                Id = entity.Id,
                StudentId = entity.StudentId,
                ActivityId = entity.ActivityId,
                //StudentName = $"{entity.Student.FirstName} {entity.Student.LastName}",
                GradeValue = entity.GradeValue,
                GradeDate = entity.GradeDate,
                Description = entity.Description,
                StudentName = entity.StudentName
            };

    public GradeListModel MapToListModel(GradeDetailModel detail)
        => new GradeListModel
        {
            Id = detail.Id,
            StudentId = detail.StudentId,
            ActivityId = detail.ActivityId,
            StudentName = detail.StudentName,
            GradeValue = detail.GradeValue,
            GradeDate = detail.GradeDate,
            Description = detail.Description
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
                // StudentName = $"{entity.Student.FirstName} {entity.Student.LastName}",
                StudentId = entity.StudentId,
                ActivityId = entity.ActivityId,
                GradeValue = entity.GradeValue,
                GradeDate = entity.GradeDate,
                StudentName = entity.StudentName,
                Description = entity.Description
            };
        }
    }

    public override GradeEntity MapToEntity(GradeDetailModel model)
        => throw new NotImplementedException("This method is unsupported. Use the other overload.");

    public GradeEntity MapToEntity(GradeDetailModel model, Guid activityId)
        => new()
        {
            Id = model.Id,
            GradeValue = model.GradeValue,
            Description = model.Description,
            GradeDate = model.GradeDate,
            ActivityId = activityId,
            StudentName = model.StudentName,
            StudentId = model.StudentId,
            Activity = null!,
            Student = null!,
        };
    
    public GradeEntity MapToEntity(GradeListModel model, Guid activityId)
        => new()
        {
            Id = model.Id,
            GradeValue = model.GradeValue,
            GradeDate = model.GradeDate,
            StudentName = model.StudentName,
            ActivityId = activityId,
            StudentId = model.StudentId,
            Activity = null!,
            Student = null!,
            Description = model.Description
        };
    
    public void MapToExistingDetailModel(GradeDetailModel existingDetailModel,
        StudentListModel student)
    {
        existingDetailModel.StudentId = student.Id;
        existingDetailModel.StudentName = $"{student.LastName} {student.FirstName}";
    }
}