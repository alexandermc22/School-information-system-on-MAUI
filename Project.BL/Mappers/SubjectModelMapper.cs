﻿using Project.DAL.Entities;
using Project.BL.Models;
namespace Project.BL.Mappers;

public class SubjectModelMapper(SubjectStudentsModelMapper subjectStudentsModelMapper)
    : ModelMapperBase<SubjectEntity,SubjectDetailModel,SubjectListModel>
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
        => new()
        {
            Id = model.Id,
            Name = model.Name,
            Code = model.Code,
            StudentSubject = null!,
            Actions = null!,
            ImageUrl = model.ImageUrl
        };
    
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
                Name = entity.Name,
                Code = entity.Code,
                ImageUrl = entity.ImageUrl,
                SubjectStudents = subjectStudentsModelMapper.MapToListModel(entity.StudentSubject).ToObservableCollection()
            };
}