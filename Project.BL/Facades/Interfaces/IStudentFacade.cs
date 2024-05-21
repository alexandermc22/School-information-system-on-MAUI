using Project.BL.Models;
using Project.DAL.Entities;

namespace Project.BL.Facades;

public interface IStudentFacade : IFacade<StudentEntity, StudentListModel , StudentDetailModel>
{
    public  Task<StudentListModel?> GetByNameAsync(string firstName, string lastName);
    public Task<IEnumerable<StudentListModel>?> GetSortAsync();
}