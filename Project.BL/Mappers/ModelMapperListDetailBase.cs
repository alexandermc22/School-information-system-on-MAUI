using Project.DAL.Entities;
using Project.BL.Models;
namespace Project.BL.Mappers;

public abstract class ModelMapperListDetailBase<TEntity,TDetailModel, TListModel> :IModelMapperDetail<TEntity,TDetailModel>,  IModelMapperList<TEntity,TListModel>
    where TEntity : IEntity
    where TListModel : IModel
    where TDetailModel : IModel
{
    public abstract TListModel MapToListModel(TEntity? entity);

    public IEnumerable<TListModel> MapToListModel(IEnumerable<TEntity> entities)
        => entities.Select(MapToListModel);

    public abstract TDetailModel MapToDetailModel(TEntity entity);
    public abstract TEntity MapToEntity(TDetailModel model);
}