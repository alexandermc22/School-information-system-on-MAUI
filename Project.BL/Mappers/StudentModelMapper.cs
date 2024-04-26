using Project.DAL.Entities;
using Project.BL.Models;
namespace Project.BL.Mappers;

public class StudentModelMapper(StudentSubjectsModelMapper studentSubjectsModelMapper)
    : ModelMapperBase<StudentEntity,StudentDetailModel,StudentListModel>
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

    public override StudentEntity MapToEntity(StudentDetailModel model)
        => new()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Photo = model.Photo,
            StudentSubject = null!
        };
    
    public  StudentEntity MapToEntity(StudentListModel model)
        => new()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Photo = model.Photo,
            StudentSubject = null!,
        };
    
    public override StudentDetailModel MapToDetailModel(StudentEntity? entity)
        => new StudentDetailModel()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Photo = entity.Photo,
            StudentSubjects = studentSubjectsModelMapper.MapToListModel(entity.StudentSubject).ToObservableCollection()
            
        };
}