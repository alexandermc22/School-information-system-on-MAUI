using Project.DAL.Entities;

namespace Project.DAL.Mappers;

public class ActionEntityMapper : IEntityMapper<ActionEntity>
{
    public void MapToExistingEntity(ActionEntity existingEntity, ActionEntity newEntity)
    {
        existingEntity.Start = newEntity.Start;
        existingEntity.End = newEntity.End;
        existingEntity.LectureRoom = existingEntity.LectureRoom;
        existingEntity.Tag = newEntity.Tag;
        existingEntity.Description = newEntity.Description;
    }
}