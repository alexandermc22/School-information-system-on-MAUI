using Microsoft.EntityFrameworkCore;
using Project.BL.Mappers;
using Project.BL.Models;
using Project.DAL.Entities;
using Project.DAL.Mappers;
using Project.DAL.Repositories;
using Project.DAL.UnitOfWork;

namespace Project.BL.Facades;

public class GradeFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    IGradeModelMapper gradeModelMapper) : 
    FacadeBase<GradeEntity,GradeDetailModel,GradeListModel,GradeEntityMapper>(unitOfWorkFactory, gradeModelMapper),
    IGradeFacade
{
    
    
    
    
    public async Task<IEnumerable<GradeListModel>?> GetGradeAsync(Guid id)
    {
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();

        IQueryable<GradeEntity> query = uow.GetRepository<GradeEntity, GradeEntityMapper>().Get();
        
        var filteredGrades = query
            .Where(a => a.ActivityId >= id)
            .ToList();
        List<GradeListModel> ALM = new List<GradeListModel>();
        foreach (var grade in filteredGrades)
        {
            ALM.Add(ModelMapper.MapToListModel(grade));
        }
        return ALM.Count == 0
            ? null
            : ALM;
    }
    
    public async Task SaveAsync(GradeListModel model, Guid activityId)
    {
        GradeEntity entity = gradeModelMapper.MapToEntity(model, activityId);

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<GradeEntity> repository =
            uow.GetRepository<GradeEntity, GradeEntityMapper>();

        if (await repository.ExistsAsync(entity))
        {
            await repository.UpdateAsync(entity);
            await uow.CommitAsync();
        }
    }
    
    
    public async Task SaveAsync(GradeDetailModel model, Guid activityId)
    {
        GradeEntity entity = gradeModelMapper.MapToEntity(model, activityId);
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<GradeEntity> repository =
            uow.GetRepository<GradeEntity, GradeEntityMapper>();
        
        await repository.UpdateAsync(entity);
        await uow.CommitAsync();
    }
    
    public  async Task<IEnumerable<GradeListModel>?> GetSortAsync()
    {

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();

        IQueryable<GradeEntity> query = uow.GetRepository<GradeEntity, GradeEntityMapper>().Get();
        
        IQueryable<GradeEntity> sortedGrades = query.OrderBy(s => s.Activity.Subject.Name); // TODO check if subj != null
        List<GradeListModel> GLM = new List<GradeListModel>();

        foreach (var grade  in sortedGrades)
        {
            GLM.Add( ModelMapper.MapToListModel(grade));
        }

        return GLM.Count == 0
            ? null
            : GLM;
    }
}