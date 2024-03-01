using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Project.DAL.Factories;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProjectDbContext>
{
    private readonly DbContextSqlFactory _dbContextSqLiteFactory = new($"Data Source=project;Cache=Shared");

    public ProjectDbContext CreateDbContext(string[] args) => _dbContextSqLiteFactory.CreateDbContext();
}