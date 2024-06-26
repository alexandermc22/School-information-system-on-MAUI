﻿using System.ComponentModel.Design;
using Project.DAL.Entities;
using Project.BL.Models;
namespace Project.BL.Mappers;

public class SubjectModelMapper(IActivityModelMapper subjectStudentsModelMapper)
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
            ImageUrl = model.ImageUrl,
            Activity = null!,
        };
    
    public  SubjectEntity MapToEntity(SubjectListModel model)
        => new()
        {
            Id = model.Id,
            Name = model.Name,
            Code = model.Code,
            ImageUrl = model.ImageUrl,
            Activity = null!,
        };

    public override SubjectDetailModel MapToDetailModel(SubjectEntity? entity)
    {
        if(entity is null)
            return SubjectDetailModel.Empty;
        else
        {
            if (entity.Activity != null)
                return new SubjectDetailModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Code = entity.Code,
                    ImageUrl = entity.ImageUrl,
                    Activities = subjectStudentsModelMapper.MapToListModel(entity.Activity)
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