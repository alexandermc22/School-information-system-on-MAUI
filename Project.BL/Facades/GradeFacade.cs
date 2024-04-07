using Project.BL.Mappers;
using Project.BL.Models;
using Project.DAL.Entities;
using Project.DAL.Mappers;
using Project.DAL.Repositories;
using Project.DAL.UnitOfWork;

namespace Project.BL.Facades;

public class GradeFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    GradeListDetailModelMapper gradeModelMapper) : 
    FacadeBase<GradeEntity,GradeListModel,GradeDetailModel,GradeEntityMapper>(unitOfWorkFactory, gradeModelMapper),
    IGradeFacade
{
    public async Task SaveAsync(GradeDetailModel model, Guid studentId)
    {
        GradeEntity entity = gradeModelMapper.MapToEntity(model, studentId);
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<GradeEntity> repository =
            uow.GetRepository<GradeEntity, GradeEntityMapper>();
        
        await repository.UpdateAsync(entity);
        await uow.CommitAsync();
    }
}