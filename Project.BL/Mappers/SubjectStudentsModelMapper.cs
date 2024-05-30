using Project.BL.Models;
using Project.DAL.Entities;
namespace Project.BL.Mappers;

public class SubjectStudentsModelMapper: 
    ModelMapperBase<StudentSubjectEntity,SubjectStudentsDetailModel,SubjectStudentsListModel>, ISubjectStudentsModelMapper
{
    
    public override SubjectStudentsListModel MapToListModel(StudentSubjectEntity? entity)
        => entity?.StudentId is null
            ? SubjectStudentsListModel.Empty
            : new SubjectStudentsListModel
            {
                Id = entity.Id,
                StudentId = entity.StudentId,
                StudentFirstName = entity.Student.FirstName,
                StudentLastName = entity.Student.LastName
            };
    
    public override SubjectStudentsDetailModel MapToDetailModel(StudentSubjectEntity? entity)
        => entity?.StudentId is null
            ? SubjectStudentsDetailModel.Empty
            : new SubjectStudentsDetailModel
            {
                Id = entity.Id,
                StudentId = entity.StudentId,
                StudentFirstName = entity.Student.FirstName,
                StudentLastName = entity.Student.LastName,
                StudentPhoto = entity.Student.Photo
            };
    
    public SubjectStudentsListModel MapToListModel(SubjectStudentsDetailModel detailModel)
        => new()
        {
            Id = detailModel.Id,
            StudentId = detailModel.StudentId,
            StudentFirstName = detailModel.StudentFirstName,
            StudentLastName = detailModel.StudentLastName,
        };
    
    
    public void MapToExistingDetailModel(SubjectStudentsDetailModel existingDetailModel,
        StudentListModel student)
    {
        existingDetailModel.StudentId = student.Id;
        existingDetailModel.StudentFirstName = student.FirstName;
        existingDetailModel.StudentLastName = student.LastName;
        existingDetailModel.StudentPhoto = student.Photo;
    }
    public override StudentSubjectEntity MapToEntity(SubjectStudentsDetailModel model)
        => throw new NotImplementedException("This method is unsupported. Use the other overload.");
    
    public StudentSubjectEntity MapToEntity(SubjectStudentsDetailModel model, Guid studentId, Guid subjectId)
        => new()
        {
            Id = model.Id,
            StudentId = studentId,
            SubjectId = subjectId,
            Student = null!,
            Subject = null!
        };

    public StudentSubjectEntity MapToEntity(SubjectStudentsListModel model, Guid studentId, Guid subjectId)
        => new()
        {
            Id = model.Id,
            StudentId = studentId,
            SubjectId = subjectId,
            Student = null!,
            Subject = null!
        };
}