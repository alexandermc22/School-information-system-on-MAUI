using Project.DAL.Entities;
using Project.BL.Models;
namespace Project.BL.Mappers;

public abstract class ModelMapperListBase<TEntity,TListModel> : IModelMapperList<TEntity,TListModel>
    where TEntity : IEntity
    where TListModel : IModel
{
    public abstract TListModel MapToListModel(TEntity entity);
    public abstract TEntity MapToEntity(TListModel model);
}
