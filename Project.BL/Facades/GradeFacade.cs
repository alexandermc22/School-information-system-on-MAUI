using Microsoft.EntityFrameworkCore;
using Project.BL.Mappers;
using Project.BL.Models;
using Project.DAL.Entities;
using Project.DAL.Mappers;
using Project.DAL.Repositories;
using Project.DAL.UnitOfWork;

namespace Project.BL.Facades;

public class GradeFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    GradeModelMapper gradeModelMapper) : 
    FacadeBase<GradeEntity,GradeListModel,GradeDetailModel,GradeEntityMapper>(unitOfWorkFactory, gradeModelMapper),
    IGradeFacade
{
    public async Task SaveAsync(GradeDetailModel model, Guid studentId)
    {
        GradeEntity entity = gradeModelMapper.MapToEntity(model, studentId);
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<GradeEntity> repository =
            uow.GetRepository<GradeEntity, GradeEntityMapper>();
        
        await repository.UpdateAsync(entity);
        await uow.CommitAsync();
    }
    
    public  async Task<IEnumerable<GradeListModel>?> GetSortAsync()
    {

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();

        IQueryable<GradeEntity> query = uow.GetRepository<GradeEntity, GradeEntityMapper>().Get();

        foreach (string includePath in IncludesNavigationPathDetail)
        {
            query = query.Include(includePath);
        }

        IQueryable<GradeEntity> sortedGrades = query.OrderBy(s => s.Activity.Subject.Name); // TODO check if subj != null
        List<GradeListModel> GLM = new List<GradeListModel>();

        foreach (var grade  in sortedGrades)
        {
            GLM.Add( ModelMapper.MapToListModel(grade));
        }

        return GLM.Count == 0
            ? null
            : GLM;
    }
}