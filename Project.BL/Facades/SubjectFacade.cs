﻿using Microsoft.EntityFrameworkCore;
using Project.BL.Mappers;
using Project.BL.Models;
using Project.DAL.Entities;
using Project.DAL.Mappers;
using Project.DAL.UnitOfWork;

namespace Project.BL.Facades;

public class SubjectFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    SubjectListModelMapper modelMapper)
    :
        FacadeBase<SubjectEntity, SubjectListModel, SubjectDetailModel, SubjectEntityMapper>(unitOfWorkFactory,
            modelMapper), ISubjectFacade
{
    public virtual async Task<SubjectListModel?> GetByNameAsync(string name)
    {
        if(ModelMapperList == null)
            throw new ArgumentNullException(nameof(ModelMapperList));
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();

        IQueryable<SubjectEntity> query = uow.GetRepository<SubjectEntity, SubjectEntityMapper>().Get();

        foreach (string includePath in IncludesNavigationPathDetail)
        {
            query = query.Include(includePath);
        }

        SubjectEntity? entity = await query.SingleOrDefaultAsync(e => e.Name == name).ConfigureAwait(false);

        return entity is null
            ? null
            : ModelMapperList.MapToListModel(entity);
    }
    
    public virtual async Task<List<SubjectListModel>?> GetSortAsync()
    {
        if(ModelMapperList == null)
            throw new ArgumentNullException(nameof(ModelMapperList));
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
            SLM.Add( ModelMapperList.MapToListModel(subject));
        }

        return SLM.Count == 0
            ? null
            : SLM;
    }
}