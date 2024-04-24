using Microsoft.EntityFrameworkCore;
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
            modelMapper), IStudentFacade
{
    public virtual async Task<StudentListModel?> GetByNameAsync(string firstName, string lastName)
    {
        if(ModelMapperList == null)
            throw new ArgumentNullException(nameof(ModelMapperList));
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();

        IQueryable<StudentEntity> query = uow.GetRepository<StudentEntity, StudentEntityMapper>().Get();

        foreach (string includePath in IncludesNavigationPathDetail)
        {
            query = query.Include(includePath);
        }

        StudentEntity? entity = await query.SingleOrDefaultAsync(e => (e.FirstName == firstName && e.LastName == lastName)).ConfigureAwait(false);

        return entity is null
            ? null
            : ModelMapperList.MapToListModel(entity);
    }
}
            