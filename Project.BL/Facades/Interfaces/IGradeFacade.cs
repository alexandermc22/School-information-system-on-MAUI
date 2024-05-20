using Project.BL.Models;
using Project.DAL.Entities;

namespace Project.BL.Facades;

public interface IGradeFacade : IFacade<GradeEntity, GradeListModel, GradeDetailModel>
{
    /*Task SaveAsync(GradeDetailModel model, Guid studentId);
    Task DeleteAsync(Guid id);*/
}