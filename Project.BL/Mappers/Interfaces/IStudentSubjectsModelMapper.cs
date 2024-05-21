using Project.BL.Models;
using Project.DAL.Entities;

namespace Project.BL.Mappers;

public interface IStudentSubjectsModelMapper : IModelMapper<StudentSubjectEntity, StudentSubjectsDetailModel,StudentSubjectsListModel>
{
    public StudentSubjectsListModel MapToListModel(StudentSubjectsDetailModel detailModel);

    public void MapToExistingDetailModel(StudentSubjectsDetailModel existingDetailModel,
        SubjectListModel subject);

    public StudentSubjectEntity MapToEntity(StudentSubjectsDetailModel model, Guid studentId, Guid subjectId);
    public StudentSubjectEntity MapToEntity(StudentSubjectsListModel model, Guid studentId, Guid subjectId);
}