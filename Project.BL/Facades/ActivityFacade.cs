using Microsoft.EntityFrameworkCore;
using Project.BL.Mappers;
using Project.BL.Models;
using Project.DAL.Entities;
using Project.DAL.Mappers;
using Project.DAL.Repositories;
using Project.DAL.UnitOfWork;

namespace Project.BL.Facades;

public class ActivityFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    IActivityModelMapper activityModelMapper) : 
    FacadeBase<ActivityEntity,ActivityDetailModel,ActivityListModel,ActivityEntityMapper>(unitOfWorkFactory, activityModelMapper),
    IActivityFacade
{
    
    public async Task<IEnumerable<ActivityListModel>?> GetActivityAsync(Guid id)
    {
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();

        IQueryable<ActivityEntity> query = uow.GetRepository<ActivityEntity, ActivityEntityMapper>().Get();
        
        var filteredActivities = query
            .Where(a => a.SubjectId == id)
            .ToList();
        List<ActivityListModel> ALM = new List<ActivityListModel>();
        foreach (var activity in filteredActivities)
        {
            ALM.Add(ModelMapper.MapToListModel(activity));
        }
        return ALM.Count == 0
            ? null
            : ALM;
    }
    
    
    public  async Task<IEnumerable<ActivityListModel>?> GetFilteredAsync(Guid subjectId,DateTime activityStartTime, DateTime activityEndTime)
    {

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();

        IQueryable<ActivityEntity> query = uow.GetRepository<ActivityEntity, ActivityEntityMapper>().Get();
        
        var filteredActivities = query
            .Where(a => a.Start >= activityStartTime && a.End <= activityEndTime && a.SubjectId == subjectId)
            .ToList();

        List<ActivityListModel> ALM = new List<ActivityListModel>();
        foreach (var activity in filteredActivities)
        {
            ALM.Add(ModelMapper.MapToListModel(activity));
        }
        return ALM.Count == 0
            ? null
            : ALM;
    }
    
    public  async Task<IEnumerable<ActivityListModel>?> GetFilteredAsync(Guid subjectId)
    {

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();

        IQueryable<ActivityEntity> query = uow.GetRepository<ActivityEntity, ActivityEntityMapper>().Get();
        var filteredActivities = query
            .Where(a => a.SubjectId == subjectId)
            .ToList();

        List<ActivityListModel> ALM = new List<ActivityListModel>();
        foreach (var activity in filteredActivities)
        {
            ALM.Add(ModelMapper.MapToListModel(activity));
        }
        return ALM.Count == 0
            ? null
            : ALM;
    }
    
    public async Task SaveAsync(ActivityListModel model, Guid subjectId)
    {
        ActivityEntity entity = activityModelMapper.MapToEntity(model, subjectId);
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<ActivityEntity> repository =
            uow.GetRepository<ActivityEntity, ActivityEntityMapper>();
        if (await repository.ExistsAsync(entity))
        {
            await repository.UpdateAsync(entity);
            await uow.CommitAsync();
        }
    }
    
    public async Task SaveAsync(ActivityDetailModel model, Guid subjectId)
    {
        ActivityEntity entity = activityModelMapper.MapToEntity(model, subjectId);
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<ActivityEntity> repository =
            uow.GetRepository<ActivityEntity, ActivityEntityMapper>();
        
        // await repository.UpdateAsync(entity);
        // await uow.CommitAsync();
        ActivityDetailModel result;
        if (await repository.ExistsAsync(entity).ConfigureAwait(false))
        {
            ActivityEntity updatedEntity = await repository.UpdateAsync(entity).ConfigureAwait(false);
            result = ModelMapper.MapToDetailModel(updatedEntity);
        }
        else
        {
            entity.Id = Guid.NewGuid();
            ActivityEntity insertedEntity = repository.Insert(entity);
            result = ModelMapper.MapToDetailModel(insertedEntity);
        }

        await uow.CommitAsync().ConfigureAwait(false);
    }
    
    protected override ICollection<string> IncludesNavigationPathDetail =>
        new[] {$"{nameof(ActivityEntity.Grades)}.{nameof(GradeEntity.Student)}"};
}