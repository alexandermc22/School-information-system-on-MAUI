using Project.DAL.Entities;
using Project.BL.Models;
namespace Project.BL.Mappers;

public interface IModelMapperDetail<TEntity,TDetailModel>
where TEntity : IEntity
where TDetailModel : IModel
{
    TDetailModel MapToDetailModel(TEntity entity);
    TEntity MapToEntity(TDetailModel model);
}
