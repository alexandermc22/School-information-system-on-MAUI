using Microsoft.EntityFrameworkCore;

namespace Project.DAL.UnitOfWork;

public class UnitOfWorkFactory(IDbContextFactory<ProjectDbContext> dbContextFactory) : IUnitOfWorkFactory
{
    public IUnitOfWork Create() => new UnitOfWork(dbContextFactory.CreateDbContext());
}
