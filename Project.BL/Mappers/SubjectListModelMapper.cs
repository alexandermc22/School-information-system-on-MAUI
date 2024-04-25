﻿using Project.DAL.Entities;
using Project.BL.Models;
namespace Project.BL.Mappers;

public class SubjectListModelMapper(SubjectStudentsListDetailModelMapper subjectStudentsListDetailModelMapper)
    : ModelMapperListDetailBase<SubjectEntity,SubjectDetailModel,SubjectListModel>
{

    public override SubjectListModel MapToListModel(SubjectEntity? entity)
        => entity is null
            ? SubjectListModel.Empty
            : new SubjectListModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Code = entity.Code,
                ImageUrl = entity.ImageUrl
            };
    
    public override SubjectEntity MapToEntity(SubjectDetailModel model)
        => throw new NotImplementedException("This method is unsupported. Use the other overload.");
    
    public  SubjectEntity MapToEntity(SubjectListModel model)
        => new()
        {
            Id = model.Id,
            Name = model.Name,
            Code = model.Code,
            ImageUrl = model.ImageUrl,
            StudentSubject = null!,
            Actions = null!,
        };
    
    public override SubjectDetailModel MapToDetailModel(SubjectEntity? entity)
        => new SubjectDetailModel
            {
                Id = entity.Id,
                SubjectStudents = subjectStudentsListDetailModelMapper.MapToListModel(entity.StudentSubject).ToObservableCollection()
            };
}