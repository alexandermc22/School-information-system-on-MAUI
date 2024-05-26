using Project.BL.Models;
using Project.DAL.Entities;

namespace Project.BL.Facades;

public interface IGradeFacade : IFacade<GradeEntity,GradeListModel , GradeDetailModel>
{
    
    Task<IEnumerable<GradeListModel>?> GetGradeAsync(Guid id);
    Task<GradeDetailModel> SaveAsync(GradeDetailModel model, Guid studentId);
    Task SaveAsync(GradeListModel model, Guid activityId);
    Task DeleteAsync(Guid id);
}