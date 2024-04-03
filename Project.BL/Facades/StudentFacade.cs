using Project.BL.Mappers;
using Project.BL.Models;
using Project.DAL.Entities;
using Project.DAL.Mappers;
using Project.DAL.UnitOfWork;

namespace Project.BL.Facades;

public class StudentFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    StudentListModelMapper modelMapper)
    :
        FacadeBase<StudentEntity, StudentListModel, StudentDetailModel, StudentEntityMapper>(unitOfWorkFactory,
            modelMapper), IStudentFacade;
            