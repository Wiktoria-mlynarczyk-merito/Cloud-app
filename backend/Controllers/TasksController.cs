using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("tasks")]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;

    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        return Ok(await _context.Tasks.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> AddTask(TaskItem task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return Ok(task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, TaskItem updatedTask)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
            return NotFound();

        task.Name = updatedTask.Name;
        task.IsCompleted = updatedTask.IsCompleted;

        await _context.SaveChangesAsync();

        return Ok(task);
    }
}