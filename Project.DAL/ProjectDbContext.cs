using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
// using Project.DAL.Seeds;

namespace Project.DAL;

public class ProjectDbContext(DbContextOptions contextOptions, bool seedDemoData = false) : DbContext(contextOptions)
{
    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<SubjectEntity> Subjects { get; set; }
    public DbSet<ActivityEntity> Activities { get; set; }
    public DbSet<GradeEntity> Grades { get; set; }
    public DbSet<StudentSubjectEntity> StudentSubject { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<SubjectEntity>()
            .HasMany(i => i.StudentSubject)
            .WithOne(i => i.Subject)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<SubjectEntity>()
            .HasMany(i => i.Activity)
            .WithOne(i => i.Subject)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<StudentEntity>()
            .HasMany(i => i.StudentSubject)
            .WithOne(i => i.Student)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<GradeEntity>()
            .HasOne(i => i.Activity)
            .WithMany(i => i.Grades)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<GradeEntity>()
            .HasOne(i => i.Student)
            .WithMany(i => i.Grades)
            .OnDelete(DeleteBehavior.Cascade);
        
        // modelBuilder.Entity<StudentEntity>()
        //     .HasMany<GradeEntity>()
        //     .WithOne(i => i.Student)
        //     .OnDelete(DeleteBehavior.Cascade);
        
        // if (seedDemoData)
        // {
        //     ActivitySeeds.Seed(modelBuilder);
        //     GradeSeeds.Seed(modelBuilder);
        //     StudentSeeds.Seed(modelBuilder);
        //     StudentSubjectSeeds.Seed(modelBuilder);
        //     SubjectSeeds.Seed(modelBuilder);
        // }
        
        
        
    }
    
    
}