using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RecruitBoard.Services.Candidates.Domain.Common;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Infrastructure;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) 
        : base(options) { }

    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Experience> Experiences { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());
    }

    public override Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    break;
                case EntityState.Deleted:
                    entry.Entity.Deleted = true;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}