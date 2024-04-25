
using Microsoft.EntityFrameworkCore;
using Project.BL.Mappers;
using Project.BL.Models;
using Project.DAL.Entities;
using Project.DAL.Mappers;
using Project.DAL.Repositories;
using Project.DAL.UnitOfWork;
namespace Project.BL.Facades;

public class SubjectStudentsFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    SubjectStudentsModelMapper subjectStudentsModelMapper) : 
    FacadeBase<StudentSubjectEntity,SubjectStudentsListModel,SubjectStudentsDetailModel,StudentSubjectEntityMapper>(unitOfWorkFactory, subjectStudentsModelMapper),
    ISubjectStudentsFacade
{
    
    
    
    public async Task SaveAsync(SubjectStudentsListModel model, Guid studentId, Guid subjectId)
    {
        StudentSubjectEntity entity = subjectStudentsModelMapper.MapToEntity(model,studentId, subjectId);
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<StudentSubjectEntity> repository =
            uow.GetRepository<StudentSubjectEntity, StudentSubjectEntityMapper>();
        if (await repository.ExistsAsync(entity))
        {
            await repository.UpdateAsync(entity);
            await uow.CommitAsync();
        }
    }
    
    public async Task SaveAsync(SubjectStudentsDetailModel model, Guid studentId, Guid subjectId)
    {
        StudentSubjectEntity entity = subjectStudentsModelMapper.MapToEntity(model,studentId, subjectId);
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<StudentSubjectEntity> repository =
            uow.GetRepository<StudentSubjectEntity, StudentSubjectEntityMapper>();
        
        await repository.UpdateAsync(entity);
        await uow.CommitAsync();
    }
    
    public virtual async Task<List<SubjectStudentsListModel>?> GetSortAsync()
    {

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();

        IQueryable<StudentSubjectEntity> query = uow.GetRepository<StudentSubjectEntity, StudentSubjectEntityMapper>().Get();

        foreach (string includePath in IncludesNavigationPathDetail)
        {
            query = query.Include(includePath);
        }

        IQueryable<StudentSubjectEntity> sortedStudentSubject = query.OrderBy(s => s.Student.LastName);
        List<SubjectStudentsListModel> SSLM = new List<SubjectStudentsListModel>();

        foreach (var subjectstudents  in sortedStudentSubject)
        {
            SSLM.Add( ModelMapper.MapToListModel(subjectstudents));
        }

        return SSLM.Count == 0
            ? null
            : SSLM;
    }
}