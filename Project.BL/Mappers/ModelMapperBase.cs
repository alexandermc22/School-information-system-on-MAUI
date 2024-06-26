﻿using Project.DAL.Entities;
using Project.BL.Models;
namespace Project.BL.Mappers;

public abstract class ModelMapperBase<TEntity,TDetailModel, TListModel> : IModelMapper<TEntity,TDetailModel, TListModel >
{
    public abstract TListModel MapToListModel(TEntity? entity);

    public IEnumerable<TListModel> MapToListModel(IEnumerable<TEntity> entities)
         => entities.Select(MapToListModel);

    public abstract TDetailModel MapToDetailModel(TEntity entity);
    public abstract TEntity MapToEntity(TDetailModel model);
}