using Project.BL.Models;
using Project.DAL.Entities;
namespace Project.BL.Facades;

public interface IStudentSubjectsFacade
{
    Task SaveAsync(StudentSubjectsDetailModel model, Guid studentId, Guid subjectId);
    Task SaveAsync(StudentSubjectsListModel model,  Guid studentId, Guid subjectId);
    Task DeleteAsync(Guid id);
}