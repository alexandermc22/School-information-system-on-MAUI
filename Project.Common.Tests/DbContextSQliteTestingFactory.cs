using Project.DAL;
using Microsoft.EntityFrameworkCore;
using Project.Common.Tests;

namespace Project.Common.Tests;

public class DbContextSqLiteTestingFactory(string databaseName, bool seedTestingData = false)
    : IDbContextFactory<ProjectDbContext>
{
    public ProjectDbContext CreateDbContext()
    {
        DbContextOptionsBuilder<ProjectDbContext> builder = new();
        builder.UseSqlite($"Data Source={databaseName};Cache=Shared");

        // builder.LogTo(Console.WriteLine); //Enable in case you want to see tests details, enabled may cause some inconsistencies in tests
        // builder.EnableSensitiveDataLogging();

        return new ProjectTestingDbContext(builder.Options, seedTestingData);
        
    }
}