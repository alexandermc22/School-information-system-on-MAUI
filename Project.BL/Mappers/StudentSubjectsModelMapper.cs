using Project.BL.Models;
using Project.DAL.Entities;
namespace Project.BL.Mappers;

public class StudentSubjectsModelMapper:
    ModelMapperBase<StudentSubjectEntity,StudentSubjectsDetailModel,StudentSubjectsListModel>, IStudentSubjectsModelMapper
{
    
    public override StudentSubjectsListModel MapToListModel(StudentSubjectEntity? entity)
        => entity?.SubjectId is null
            ? StudentSubjectsListModel.Empty
            : new StudentSubjectsListModel
            {
                Id = entity.Id,
                SubjectCode = entity.Subject.Code,
                SubjectId = entity.SubjectId,
                SubjectName = entity.Subject.Name
            };
    
    public override StudentSubjectsDetailModel MapToDetailModel(StudentSubjectEntity? entity)
        => entity?.SubjectId is null
            ? StudentSubjectsDetailModel.Empty
            : new StudentSubjectsDetailModel
            {
                Id = entity.Id,
                SubjectCode = entity.Subject.Code,
                SubjectId = entity.SubjectId,
                SubjectName = entity.Subject.Name,
                SubjectImageUrl = entity.Subject.ImageUrl
            };
    
    public StudentSubjectsListModel MapToListModel(StudentSubjectsDetailModel detailModel)
        => new()
        {
            Id = detailModel.Id,
            SubjectId = detailModel.SubjectId,
            SubjectCode = detailModel.SubjectCode,
            SubjectName = detailModel.SubjectName,
        };
    
    public void MapToExistingDetailModel(StudentSubjectsDetailModel existingDetailModel,
        SubjectListModel subject)
    {
        existingDetailModel.SubjectId = subject.Id;
        existingDetailModel.SubjectCode = subject.Code;
        existingDetailModel.SubjectName = subject.Name;
        existingDetailModel.SubjectImageUrl = subject.ImageUrl;
    }
    
    public override StudentSubjectEntity MapToEntity(StudentSubjectsDetailModel model)
        => throw new NotImplementedException("This method is unsupported. Use the other overload.");
    
    public StudentSubjectEntity MapToEntity(StudentSubjectsDetailModel model, Guid studentId, Guid subjectId)
        => new()
        {
            Id = model.Id,
            StudentId = studentId,
            SubjectId = subjectId,
            Student = null!,
            Subject = null!
        };

    public StudentSubjectEntity MapToEntity(StudentSubjectsListModel model, Guid studentId, Guid subjectId)
        => new()
        {
            Id = model.Id,
            StudentId = studentId,
            SubjectId = subjectId,
            Student = null!,
            Subject = null!
        };
}

