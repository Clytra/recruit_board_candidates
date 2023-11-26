namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Queries.GetCandidate;

public class ExperienceDto
{
    public string CompanyName { get; set; }
    public string Position { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}