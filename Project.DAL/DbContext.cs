using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;

namespace Project.DAL;

public class ProjectDbContext(DbContextOptions contextOptions, bool seedDemoData = false) : DbContext(contextOptions)
{
    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<SubjectEntity> Subjects { get; set; }
    public DbSet<ActionEntity> Actions { get; set; }
    public DbSet<GradeEntity> Grades { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<SubjectEntity>()
            .HasMany(i => i.Students)
            .WithOne(i => i.Subject)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<StudentEntity>()
            .HasMany<StudentSubjectEntity>()
            .WithOne(i => i.Student)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<ActionEntity>();
            
        
        modelBuilder.Entity<GradeEntity>();
        
        
    }
}