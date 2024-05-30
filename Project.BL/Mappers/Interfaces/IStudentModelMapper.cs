using Project.BL.Models;
using Project.DAL.Entities;

namespace Project.BL.Mappers;

public interface IStudentModelMapper : IModelMapper<StudentEntity,StudentDetailModel,StudentListModel>
{
    public StudentEntity MapToEntity(StudentListModel model);
}