using Project.BL.Models;
using Project.DAL.Entities;
namespace Project.BL.Facades;

public interface IStudentSubjectsFacade
{
    Task SaveAsync(StudentSubjectsDetailModel model, Guid studentId);
    Task SaveAsync(StudentSubjectsListModel model,  Guid studentId);
    Task DeleteAsync(Guid id);
}