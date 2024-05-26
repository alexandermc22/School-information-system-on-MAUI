using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Project.BL.Mappers;
using Project.BL.Models;
using Project.DAL.Entities;
using Project.DAL.Mappers;
using Project.DAL.UnitOfWork;

namespace Project.BL.Facades;

public class SubjectFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    ISubjectModelMapper modelMapper)
    :
        FacadeBase<SubjectEntity,SubjectDetailModel, SubjectListModel, SubjectEntityMapper>(unitOfWorkFactory,
            modelMapper), ISubjectFacade
{
    public async Task<IEnumerable<SubjectListModel>?> GetByNameAsync(string code)
    {
        // Проверка на пустые строки
        if (string.IsNullOrEmpty(code))
        {
            return await base.GetAsync();
        }

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();

        IQueryable<SubjectEntity> query = uow.GetRepository<SubjectEntity, SubjectEntityMapper>().Get();

        // Формирование условий фильтрации
        IQueryable<SubjectEntity> filteredSubjects = query;

        filteredSubjects = filteredSubjects.Where(s => s.Code == code || s.Name== code);
        
        // Преобразование отфильтрованных студентов в модели списка
        List<SubjectListModel> SLM = await filteredSubjects
            .OrderBy(s => s.Code)
            .Select(subject => ModelMapper.MapToListModel(subject))
            .ToListAsync();

        return SLM.Count == 0 ? null : SLM;
    }
    
    public  async Task<IEnumerable<SubjectListModel>?> GetSortAsync()
    {

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();

        IQueryable<SubjectEntity> query = uow.GetRepository<SubjectEntity, SubjectEntityMapper>().Get();

        foreach (string includePath in IncludesNavigationPathDetail)
        {
            query = query.Include(includePath);
        }

        IQueryable<SubjectEntity> sortedSubjects = query.OrderBy(s => s.Name);
        List<SubjectListModel> SLM = new List<SubjectListModel>();

        foreach (var subject  in sortedSubjects)
        {
            SLM.Add( ModelMapper.MapToListModel(subject));
        }

        return SLM.Count == 0
            ? null
            : SLM;
    }
    
    protected override ICollection<string> IncludesNavigationPathDetail =>
        new[] {$"{nameof(SubjectEntity.Activity)}"};
}