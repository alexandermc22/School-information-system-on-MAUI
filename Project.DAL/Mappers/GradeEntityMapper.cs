using Project.DAL.Entities;

namespace Project.DAL.Mappers;

public class GradeEntityMapper : IEntityMapper<GradeEntity>
{
    public void MapToExistingEntity(GradeEntity existingEntity, GradeEntity newEntity)
    {
        existingEntity.Score = newEntity.Score;
        existingEntity.Description = newEntity.Description;
        // ?
        existingEntity.Action = newEntity.Action;
        existingEntity.Student = newEntity.Student;
    }
}