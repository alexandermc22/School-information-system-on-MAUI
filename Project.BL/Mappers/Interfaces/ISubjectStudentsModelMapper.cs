using Project.BL.Models;
using Project.DAL.Entities;

namespace Project.BL.Mappers;

public interface ISubjectStudentsModelMapper : IModelMapper<StudentSubjectEntity, SubjectStudentsDetailModel,SubjectStudentsListModel>
{
    public SubjectStudentsListModel MapToListModel(SubjectStudentsDetailModel detailModel);

    public void MapToExistingDetailModel(SubjectStudentsDetailModel existingDetailModel,
        StudentListModel student);

    public StudentSubjectEntity MapToEntity(SubjectStudentsDetailModel model, Guid studentId, Guid subjectId);
    public StudentSubjectEntity MapToEntity(SubjectStudentsListModel model, Guid studentId, Guid subjectId);
}