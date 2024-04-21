using Project.BL.Models;
using Project.DAL.Entities;

namespace Project.BL.Facades;

public interface IStudentFacade : IFacade<StudentEntity, StudentListModel , StudentDetailModel>
{
    
}