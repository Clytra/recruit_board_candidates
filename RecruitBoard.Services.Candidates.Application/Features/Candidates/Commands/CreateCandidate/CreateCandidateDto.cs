namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.CreateCandidate;

public class CreateCandidateDto
{
    public Guid CandidateId { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
}