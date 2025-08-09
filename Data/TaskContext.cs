using api_test.Models;
using Microsoft.EntityFrameworkCore;

namespace api_test.Data;

public class TaskContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=task.sqlite");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<TodoTask> Tasks { get; set; } = null!;
}