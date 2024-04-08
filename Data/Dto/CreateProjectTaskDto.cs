namespace YakimGamesTaskBundle.Data.Dto;

public class CreateProjectTaskDto
{
    public string Description { get; set; }
    public string DifficultyLevel { get; set; }
    public int ProgressGoal { get; set; }
    public int? BundleId { get; set; }
}