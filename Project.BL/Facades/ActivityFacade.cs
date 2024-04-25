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
    ActivityListDetailModelMapper activityModelMapper) : 
    FacadeBase<ActivityEntity,ActivityListModel,ActivityDetailModel,ActivityEntityMapper>(unitOfWorkFactory, activityModelMapper),
    IActivityFacade
{
    
    public  async Task<List<ActivityListModel>?> GetFilteredAsync(Guid subjectId,DateTime activityStartTime, DateTime activityEndTime)
    {
        if(ModelMapperList == null)
            throw new ArgumentNullException(nameof(ModelMapperList));
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();

        IQueryable<ActivityEntity> query = uow.GetRepository<ActivityEntity, ActivityEntityMapper>().Get();

        foreach (string includePath in IncludesNavigationPathDetail)
        {
            query = query.Include(includePath);
        }
        var filteredActivities = query
            .Where(a => a.Start >= activityStartTime && a.End <= activityEndTime && a.SubjectId == subjectId)
            .ToList();

        List<ActivityListModel> ALM = new List<ActivityListModel>();
        foreach (var activity in filteredActivities)
        {
            ALM.Add(ModelMapperList.MapToListModel(activity));
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
        
        await repository.UpdateAsync(entity);
        await uow.CommitAsync();
    }
}