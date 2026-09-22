using Microsoft.EntityFrameworkCore;

using TaskPulse.Api.Data.Configurations;
using TaskPulse.Api.Models.Entities;

namespace TaskPulse.Api.Data;

public class TaskPulseDbContext : DbContext
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectMember> ProjectMembers { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<User> Users { get; set; }

    public TaskPulseDbContext(DbContextOptions<TaskPulseDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ProjectConfig());
        builder.ApplyConfiguration(new ProjectMemberConfig());
        builder.ApplyConfiguration(new TaskItemConfig());
        builder.ApplyConfiguration(new UserConfig());

        builder.Entity<TaskItem>().HasQueryFilter(t => !t.IsDeleted);
        builder.Entity<Project>().HasQueryFilter(p => !p.IsDeleted);

        base.OnModelCreating(builder);
    }
}
