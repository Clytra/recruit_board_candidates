namespace RecruitBoard.Services.Candidates.Application.Dtos;

public class ExperienceDto
{
    public string CompanyName { get; set; }
    public string Position { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}