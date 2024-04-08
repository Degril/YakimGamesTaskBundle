using Microsoft.EntityFrameworkCore;
using YakimGamesTaskBundle.Data;

public class TasksContext : DbContext
{
    public DbSet<ProjectTask> TaskItems { get; set; }
    public DbSet<TaskBundle> TaskBundles { get; set; }

 
    public TasksContext(DbContextOptions<TasksContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=tasks.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ProjectTask>()
            .HasOne<TaskBundle>() 
            .WithMany(b => b.Tasks)
            .HasForeignKey(t => t.BundleId);
    }

}