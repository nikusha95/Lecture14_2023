using System.Reflection;
using ApiWithDatabase.Configurations;
using ApiWithDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiWithDatabase;

public class UniversityDBContext : DbContext
{
    public DbSet<Semester> Semesters { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    
    public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SemesterConfiguration).Assembly);
    }
}