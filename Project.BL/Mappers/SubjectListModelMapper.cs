using Project.DAL.Entities;
using Project.BL.Models;
namespace Project.BL.Mappers;

public class SubjectListModelMapper
    : ModelMapperListBase<SubjectEntity,SubjectListModel>
{

    public override SubjectListModel MapToListModel(SubjectEntity? entity)
        => entity is null
            ? SubjectListModel.Empty
            : new SubjectListModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Code = entity.Code
            };

    public override SubjectEntity MapToEntity(SubjectListModel model)
        => new()
        {
            Id = model.Id,
            Name = model.Name,
            Code = model.Code,
            StudentSubject = null!,
            Actions = null!,
        };
}