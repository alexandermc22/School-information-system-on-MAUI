using Project.DAL.Entities;

namespace Project.DAL.Mappers;

public class StudentSubjectEntityMapper : IEntityMapper<StudentSubjectEntity>
{
    public void MapToExistingEntity(StudentSubjectEntity existingEntity, StudentSubjectEntity newEntity)
    {
        existingEntity.Student = newEntity.Student;
        existingEntity.Subject = newEntity.Subject;
    }
}