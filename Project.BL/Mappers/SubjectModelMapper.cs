﻿using System.ComponentModel.Design;
using Project.DAL.Entities;
using Project.BL.Models;
namespace Project.BL.Mappers;

public class SubjectModelMapper(ISubjectStudentsModelMapper subjectStudentsModelMapper)
    : ModelMapperBase<SubjectEntity,SubjectDetailModel,SubjectListModel>, ISubjectModelMapper
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
            ImageUrl = model.ImageUrl
        };
    
    public  SubjectEntity MapToEntity(SubjectListModel model)
        => new()
        {
            Id = model.Id,
            Name = model.Name,
            Code = model.Code,
            ImageUrl = model.ImageUrl,
        };

    public override SubjectDetailModel MapToDetailModel(SubjectEntity? entity)
    {
        if(entity is null)
            return SubjectDetailModel.Empty;
        else
        {
            if (entity.StudentSubject != null)
                return new SubjectDetailModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Code = entity.Code,
                    ImageUrl = entity.ImageUrl,
                    SubjectStudents = subjectStudentsModelMapper.MapToListModel(entity.StudentSubject)
                        .ToObservableCollection()
                };
            else
                return new SubjectDetailModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Code = entity.Code,
                    ImageUrl = entity.ImageUrl,
                };

        }
   
    }
            
}