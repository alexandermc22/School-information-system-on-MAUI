using Project.DAL.Entities;

namespace Project.DAL.Mappers;

public class GradeEntityMapper : IEntityMapper<GradeEntity>
{
    public void MapToExistingEntity(GradeEntity existingEntity, GradeEntity newEntity)
    {
        existingEntity.MarkValue = newEntity.MarkValue;
        existingEntity.Description = newEntity.Description;
        // ?
        existingEntity.Activity = newEntity.Activity;
        existingEntity.Student = newEntity.Student;
    }
}