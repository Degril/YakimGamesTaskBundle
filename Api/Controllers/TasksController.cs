using Microsoft.EntityFrameworkCore;
using YakimGamesTaskBundle.Data;
using YakimGamesTaskBundle.Data.Dto;

namespace YakimGamesTaskBundle;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly TasksContext _context;

    public TasksController(TasksContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<ProjectTask>> GetAllTasks()
    {
        return _context.TaskItems.ToList();
    }
    
    [HttpPost]
    public async Task<ActionResult<ProjectTask>> CreateTask(CreateProjectTaskDto taskDto)
    {
        var task = new ProjectTask(taskDto);

        _context.TaskItems.Add(task);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction("GetTaskById", new { id = task.Id }, task);
    } 
    
    [HttpGet("{id}")]
    public ActionResult<ProjectTask> GetTaskById(int id)
    {
        var task = _context.TaskItems.Find(id);
        if (task == null)
        {
            return NotFound();
        }
        return task;
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, CreateProjectTaskDto taskDto)
    {
        var task = new ProjectTask(taskDto);
        if (id != task.Id)
        {
            return BadRequest();
        }
        _context.Entry(task).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TaskExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }
    private bool TaskExists(int id)
    {
        return _context.TaskItems.Any(e => e.Id == id);
    }

    [HttpPut("{taskId}/BundleId")]
    public async Task<IActionResult> UpdateTaskBundle(int taskId, [FromBody] int? bundleId)
    {
        var task = await _context.TaskItems.FindAsync(taskId);
        if (task == null)
        {
            return NotFound($"Task with ID {taskId} not found.");
        }

        if (bundleId.HasValue)
        {
            var bundleExists = await _context.TaskBundles.AnyAsync(b => b.Id == bundleId.Value);
            if (!bundleExists)
            {
                return NotFound($"TaskBundle with ID {bundleId.Value} not found.");
            }
        }

        task.BundleId = bundleId;
    
        await _context.SaveChangesAsync();

        return NoContent();
    }
    [HttpPut("{id}/Progress")]
    public async Task<IActionResult> UpdateTaskProgress(int id, [FromBody] int currentProgress)
    {
        var task = await _context.TaskItems.FindAsync(id);
        if (task == null)
        {
            return NotFound($"Task with ID {id} not found.");
        }

        task.CurrentProgress = currentProgress;

        if (task.CurrentProgress > task.ProgressGoal)
        {
            return BadRequest("Current progress exceeds the progress goal.");
        }

        await _context.SaveChangesAsync();

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _context.TaskItems.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }

        _context.TaskItems.Remove(task);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
}