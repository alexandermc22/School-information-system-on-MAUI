using Project.DAL.Entities;

namespace Project.DAL.Mappers;

public class GradeEntityMapper : IEntityMapper<GradeEntity>
{
    public void MapToExistingEntity(GradeEntity existingEntity, GradeEntity newEntity)
    {
        existingEntity.GradeValue = newEntity.GradeValue;
        existingEntity.Description = newEntity.Description;
        // ?
        existingEntity.Activity = newEntity.Activity;
        existingEntity.Student = newEntity.Student;
        existingEntity.StudentId = newEntity.StudentId;
        existingEntity.ActivityId = newEntity.ActivityId;
        existingEntity.StudentName = newEntity.StudentName;
    }
}