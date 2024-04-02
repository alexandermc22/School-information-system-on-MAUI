using Project.DAL.Entities;

namespace Project.DAL.Mappers;

public class StudentEntityMapper : IEntityMapper<StudentEntity>
{
    public void MapToExistingEntity(StudentEntity existingEntity, StudentEntity newEntity)
    {
        existingEntity.FirstName = newEntity.FirstName;
        existingEntity.LastName = newEntity.LastName;
        existingEntity.Photo = newEntity.Photo;
    }
}