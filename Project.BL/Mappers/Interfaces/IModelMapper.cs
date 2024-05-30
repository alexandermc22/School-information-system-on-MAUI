namespace Project.BL.Mappers;

public interface IModelMapper<TEntity, TDetailModel, out TListModel>
{
    TListModel MapToListModel(TEntity? entity);

    IEnumerable<TListModel> MapToListModel(IEnumerable<TEntity> entities)
        => entities.Select(MapToListModel);

    TDetailModel MapToDetailModel(TEntity entity);
    TEntity MapToEntity(TDetailModel model);
}
