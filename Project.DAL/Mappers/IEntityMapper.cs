using Project.DAL.Entities;

namespace Project.DAL.Mappers;

public interface IEntityMapper<in TEntyty>
    where TEntyty : IEntity
{
    void MapToExistingEntity(TEntyty existingEntity, TEntyty newEntity);
}   