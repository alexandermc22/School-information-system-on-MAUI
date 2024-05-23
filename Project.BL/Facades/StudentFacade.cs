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
    public async Task<IEnumerable<StudentListModel>?> GetByNameAsync(string lastName, string firstName)
    {
        // Проверка на пустые строки
        if (string.IsNullOrWhiteSpace(lastName) && string.IsNullOrWhiteSpace(firstName))
        {
            // Если оба параметра пустые, вернуть пустой список
            return new List<StudentListModel>();
        }

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();

        IQueryable<StudentEntity> query = uow.GetRepository<StudentEntity, StudentEntityMapper>().Get();

        // Формирование условий фильтрации
        IQueryable<StudentEntity> filteredStudents = query;
        if (!string.IsNullOrWhiteSpace(lastName))
        {
            filteredStudents = filteredStudents.Where(s => s.LastName == lastName);
        }
        if (!string.IsNullOrWhiteSpace(firstName))
        {
            filteredStudents = filteredStudents.Where(s => s.FirstName == firstName);
        }

        // Преобразование отфильтрованных студентов в модели списка
        List<StudentListModel> SLM = await filteredStudents
            .OrderBy(s => s.LastName)
            .Select(student => ModelMapper.MapToListModel(student))
            .ToListAsync();

        return SLM.Count == 0 ? null : SLM;
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
            