using Microsoft.EntityFrameworkCore;
using YakimGamesTaskBundle.Data;
using YakimGamesTaskBundle.Data.Dto;

namespace YakimGamesTaskBundle;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class TaskBundlesController : ControllerBase
{
    private readonly TasksContext _context;

    public TaskBundlesController(TasksContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskBundle>>> GetTaskBundles()
    {
        return await _context.TaskBundles.Include(tb => tb.Tasks).ToListAsync();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskBundle>> GetTaskBundle(int id)
    {
        var taskBundle = await _context.TaskBundles
            .Include(tb => tb.Tasks)
            .FirstOrDefaultAsync(tb => tb.Id == id);

        if (taskBundle == null)
        {
            return NotFound();
        }

        return taskBundle;
    }
    
    [HttpPost]
    public async Task<ActionResult<TaskBundle>> CreateTaskBundle(CreateTaskBundleDto taskBundleDto)
    {
        var taskBundle = new TaskBundle(taskBundleDto);
        _context.TaskBundles.Add(taskBundle);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTaskBundle", new { id = taskBundle.Id }, taskBundle);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTaskBundle(int id, CreateTaskBundleDto taskBundleDto)
    {
        var taskBundle = new TaskBundle(taskBundleDto);
        if (id != taskBundle.Id)
        {
            return BadRequest();
        }

        _context.Entry(taskBundle).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TaskBundleExists(id))
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
    
    private bool TaskBundleExists(int id)
    {
        return _context.TaskBundles.Any(e => e.Id == id);
    }

    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTaskBundle(int id)
    {
        var taskBundle = await _context.TaskBundles.FindAsync(id);
        if (taskBundle == null)
        {
            return NotFound();
        }

        _context.TaskBundles.Remove(taskBundle);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}