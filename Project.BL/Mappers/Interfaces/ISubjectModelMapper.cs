using Project.BL.Models;
using Project.DAL.Entities;

namespace Project.BL.Mappers;

public interface ISubjectModelMapper : IModelMapper<SubjectEntity,SubjectDetailModel,SubjectListModel>
{
    public SubjectEntity MapToEntity(SubjectListModel model);
}