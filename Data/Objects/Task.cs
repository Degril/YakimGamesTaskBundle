using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using YakimGamesTaskBundle.Data.Dto;

namespace YakimGamesTaskBundle.Data;

public class ProjectTask
{
    [Key]
    public int Id { get; set; }
    public string Description { get; set; }
    public string DifficultyLevel { get; set; }
    public int CurrentProgress { get; set; }
    public int ProgressGoal { get; set; }
    public int? BundleId { get; set; }
    
    [JsonIgnore]
    public TaskBundle? Bundle { get; set; }

    public bool IsCompleted => CurrentProgress >= ProgressGoal;

    public ProjectTask() {}
    public ProjectTask(CreateProjectTaskDto dto)
    {
        Description = dto.Description;
        DifficultyLevel = dto.DifficultyLevel;
        ProgressGoal = dto.ProgressGoal;
        BundleId = dto.BundleId;
    }
}