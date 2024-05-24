using Project.BL.Models;
using Project.DAL.Entities;

namespace Project.BL.Facades;

public interface IStudentFacade : IFacade<StudentEntity, StudentListModel , StudentDetailModel>
{
    public  Task<IEnumerable<StudentListModel>?> GetByNameAsync(string firstName);
    public Task<IEnumerable<StudentListModel>?> GetSortAsync();
}