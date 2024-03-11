using Microsoft.EntityFrameworkCore;
using Task = TasksManager.Domain.Entity.Task;

namespace TasksManager.Infrastructure.DataContext;

public class TaskContext : DbContext
{
    public TaskContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>()
            .HasIndex(p => new { p.TaskId })
            .IsUnique(true);
    }

    public DbSet<Task> Tasks { get; set; }
    
}