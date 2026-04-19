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

    // 🔹 GET – pobierz wszystkie zadania
    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        return Ok(await _context.Tasks.ToListAsync());
    }

    // 🔹 POST – dodaj nowe zadanie
    [HttpPost]
    public async Task<IActionResult> AddTask(TaskItem task)
    {
        if (string.IsNullOrWhiteSpace(task.Name))
            return BadRequest("Task name is required");

        task.IsCompleted = false; // 🔥 zabezpieczenie

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

   
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
            return NotFound();

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return Ok();
    }
}