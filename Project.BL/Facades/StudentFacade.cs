using Microsoft.EntityFrameworkCore;
using Project.BL.Mappers;
using Project.BL.Models;
using Project.DAL.Entities;
using Project.DAL.Mappers;
using Project.DAL.UnitOfWork;

namespace Project.BL.Facades;

public class StudentFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    IStudentModelMapper modelMapper)
    :
        FacadeBase<StudentEntity,StudentDetailModel, StudentListModel, StudentEntityMapper>(unitOfWorkFactory,
            modelMapper), IStudentFacade
{
    public  async Task<StudentListModel?> GetByNameAsync(string firstName, string lastName)
    {
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();

        IQueryable<StudentEntity> query = uow.GetRepository<StudentEntity, StudentEntityMapper>().Get();
        

        StudentEntity? entity = await query.SingleOrDefaultAsync(e => (e.FirstName == firstName && e.LastName == lastName)).ConfigureAwait(false);

        return entity is null
            ? null
            : ModelMapper.MapToListModel(entity);
    }
    
    public  async Task<IEnumerable<StudentListModel>?> GetSortAsync()
    {

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();

        IQueryable<StudentEntity> query = uow.GetRepository<StudentEntity, StudentEntityMapper>().Get();
        

        IQueryable<StudentEntity> sortedStudents = query.OrderBy(s => s.LastName);
        List<StudentListModel> SLM = new List<StudentListModel>();

        foreach (var student  in sortedStudents)
        {
            SLM.Add( ModelMapper.MapToListModel(student));
        }

        return SLM.Count == 0
            ? null
            : SLM;
    }
    
    protected override ICollection<string> IncludesNavigationPathDetail =>
        new[] {$"{nameof(StudentEntity.StudentSubject)}.{nameof(StudentSubjectEntity.Subject)}"};
    
}
            