﻿using Project.BL.Models;
using Project.DAL.Entities;

namespace Project.BL.Facades;

public interface IGradeFacade : IFacade<GradeEntity,GradeListModel , GradeDetailModel>
{
    
    Task<IEnumerable<GradeListModel>?> GetGradeAsync(Guid id);
    Task SaveAsync(GradeDetailModel model, Guid studentId);
    Task DeleteAsync(Guid id);
}