using api_test.Data;
using api_test.Models;
using Microsoft.EntityFrameworkCore;

namespace api_test.Routes;

public static class TaskRoutes
{
    public static void UseRoutes(this WebApplication app)
    {
        var group = app.MapGroup("Task");

        group.MapGet("", async (TaskContext context) =>
        {
            var tasks = await context.Tasks.ToListAsync();
            return Results.Ok(tasks);
        });

        group.MapPost("", async (RequestTask req, TaskContext context) =>
        {
            var task = new TodoTask()
            {
                Description = req.Description,
                Title = req.Title,
            };
            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();
            return Results.Ok(task);
        });

        group.MapPatch("{id}", async (Guid id, bool isDone, TaskContext context) =>
        {
            var task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
                return Results.NotFound();

            task.IsDone = isDone;
            await context.SaveChangesAsync();
            return Results.Ok(task);
        });

        group.MapDelete("{id}", async (Guid id, TaskContext context) =>
        {
            var task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
                return Results.NotFound();

            context.Tasks.Remove(task);
            await context.SaveChangesAsync();
            return Results.Ok(task);
        });
    }
}