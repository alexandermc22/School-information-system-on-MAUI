using Project.Common.Tests.Seeds;
using Project.DAL;
using Microsoft.EntityFrameworkCore;
using ActivitySeeds = Project.Common.Tests.Seeds.ActivitySeeds;
using GradeSeeds = Project.Common.Tests.Seeds.GradeSeeds;

namespace Project.Common.Tests;

public class ProjectTestingDbContext(DbContextOptions contextOptions, bool seedTestingData = false)
    : ProjectDbContext(contextOptions, seedDemoData: false)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        if (seedTestingData)
        {
            SubjectSeeds.Seed(modelBuilder);
            ActivitySeeds.Seed(modelBuilder);
            GradeSeeds.Seed(modelBuilder);
            StudentSeeds.Seed(modelBuilder);
            StudentSubjectSeeds.Seed(modelBuilder);
            
        }
    }
}