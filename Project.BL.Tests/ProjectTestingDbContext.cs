using Project.DAL;
using Microsoft.EntityFrameworkCore;

namespace Project.BL.Tests;

public class ProjectTestingDbContext(DbContextOptions contextOptions, bool seedTestingData = false)
    : ProjectDbContext(contextOptions, seedDemoData: false)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        if (seedTestingData)
        {
            // ActivitySeeds.Seed(modelBuilder);
            // GradeSeeds.Seed(modelBuilder);
            // StudentSeeds.Seed(modelBuilder);
            // StudentSubjectSeeds.Seed(modelBuilder);
            // SubjectSeeds.Seed(modelBuilder);
        }
    }
}