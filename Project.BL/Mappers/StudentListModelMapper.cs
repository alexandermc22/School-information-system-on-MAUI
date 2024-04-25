using Project.DAL.Entities;
using Project.BL.Models;
namespace Project.BL.Mappers;

public class StudentListModelMapper(StudentSubjectsListDetailModelMapper studentSubjectsListDetailModelMapper)
    : ModelMapperListDetailBase<StudentEntity,StudentDetailModel,StudentListModel>
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
        => throw new NotImplementedException("This method is unsupported. Use the other overload.");
    
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
            StudentSubjects = studentSubjectsListDetailModelMapper.MapToListModel(entity.StudentSubject).ToObservableCollection()
        };
}