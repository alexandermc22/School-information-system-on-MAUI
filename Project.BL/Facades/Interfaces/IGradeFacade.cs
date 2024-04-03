using Project.BL.Models;

namespace Project.BL.Facades;

public interface IGradeFacade
{
    Task SaveAsync(GradeDetailModel model, Guid studentId);
    Task DeleteAsync(Guid id);
}