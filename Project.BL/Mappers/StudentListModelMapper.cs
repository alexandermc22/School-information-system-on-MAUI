using Project.DAL.Entities;
using Project.BL.Models;
namespace Project.BL.Mappers;

public class StudentListModelMapper
    : ModelMapperListBase<StudentEntity,StudentListModel>
{

    public override StudentListModel MapToListModel(StudentEntity? entity)
        => entity is null
            ? StudentListModel.Empty
            : new StudentListModel
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Photo = entity.Photo
            };

    public override StudentEntity MapToEntity(StudentListModel model)
        => new()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Photo = model.Photo,
            StudentSubject = null!,
        };

}