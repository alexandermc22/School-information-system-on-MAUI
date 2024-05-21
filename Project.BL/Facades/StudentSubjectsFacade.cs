
using Microsoft.EntityFrameworkCore;
using Project.BL.Mappers;
using Project.BL.Models;
using Project.DAL.Entities;
using Project.DAL.Mappers;
using Project.DAL.Repositories;
using Project.DAL.UnitOfWork;
namespace Project.BL.Facades;

public class StudentSubjectsFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    IStudentSubjectsModelMapper studentSubjectsModelMapper) : 
    FacadeBase<StudentSubjectEntity,StudentSubjectsDetailModel,StudentSubjectsListModel,StudentSubjectEntityMapper>(unitOfWorkFactory, studentSubjectsModelMapper),
    IStudentSubjectsFacade
{
    public async Task SaveAsync(StudentSubjectsListModel model, Guid studentId, Guid subjectId)
    {
        StudentSubjectEntity entity = studentSubjectsModelMapper.MapToEntity(model,studentId, subjectId);
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<StudentSubjectEntity> repository =
            uow.GetRepository<StudentSubjectEntity, StudentSubjectEntityMapper>();
        if (await repository.ExistsAsync(entity))
        {
            await repository.UpdateAsync(entity);
            await uow.CommitAsync();
        }
    }
    
    public async Task SaveAsync(StudentSubjectsDetailModel model, Guid studentId, Guid subjectId)
    {
        StudentSubjectEntity entity = studentSubjectsModelMapper.MapToEntity(model,studentId, subjectId);
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<StudentSubjectEntity> repository =
            uow.GetRepository<StudentSubjectEntity, StudentSubjectEntityMapper>();
        
        await repository.UpdateAsync(entity);
        await uow.CommitAsync();
    }
    
    public  async Task<IEnumerable<StudentSubjectsListModel>?> GetSortAsync()
    {

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();

        IQueryable<StudentSubjectEntity> query = uow.GetRepository<StudentSubjectEntity, StudentSubjectEntityMapper>().Get();
        IQueryable<StudentSubjectEntity> sortedStudentSubject = query.OrderBy(s => s.Subject.Name);
        List<StudentSubjectsListModel> SSLM = new List<StudentSubjectsListModel>();

        foreach (var studentSubjects  in sortedStudentSubject)
        {
            SSLM.Add( ModelMapper.MapToListModel(studentSubjects));
        }

        return SSLM.Count == 0
            ? null
            : SSLM;
    }
    
}