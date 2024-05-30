using Project.BL.Models;
using Project.DAL.Entities;

namespace Project.BL.Facades;

public interface ISubjectFacade : IFacade<SubjectEntity, SubjectListModel , SubjectDetailModel>
{
    public Task<IEnumerable<SubjectListModel>?> GetSortAsync();
    Task<IEnumerable<SubjectListModel>?> GetByNameAsync(string code);
}