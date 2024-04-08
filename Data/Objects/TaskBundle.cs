using System.ComponentModel.DataAnnotations;
using YakimGamesTaskBundle.Data.Dto;

namespace YakimGamesTaskBundle.Data;

public class TaskBundle
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<ProjectTask> Tasks { get; } = new List<ProjectTask>();
    
    public bool IsCompleted => Tasks.All(task => task.IsCompleted);
    
    public TaskBundle() {}
    public TaskBundle(CreateTaskBundleDto dto)
    {
        Name = dto.Name;
        Description = dto.Description;
    }
}