using Project.BL.Models;
namespace Project.BL.Facades;

public interface ISubjectStudentsFacade
{
    Task SaveAsync(SubjectStudentsDetailModel model, Guid studentId, Guid subjectId);
    Task SaveAsync(SubjectStudentsListModel model,  Guid studentId, Guid subjectId);
    Task DeleteAsync(Guid id);
}