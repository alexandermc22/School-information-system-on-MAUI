using Project.DAL.Entities;
using Project.BL.Models;
namespace Project.BL.Mappers;

public interface IModelMapperList<TEntity, out TListModel>
    where TEntity : IEntity
    where TListModel : IModel
{
    TListModel MapToListModel(TEntity? entity);

    IEnumerable<TListModel> MapToListModel(IEnumerable<TEntity> entities)
        => entities.Select(MapToListModel);
}