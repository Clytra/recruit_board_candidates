using MediatR;

namespace RecruitBoard.Services.Candidates.Application.Features.Experiences.Commands.CreateExperience;

public class CreateExperienceCommand(
    string companyName,
    string position,
    DateTime startDate,
    DateTime? endDate,
    Guid candidateId)
    : IRequest<CreateExperienceCommandResponse>
{
    public string CompanyName { get; set; } = companyName;
    public string Position { get; set; } = position;
    public DateTime StartDate { get; set; } = startDate;
    public DateTime? EndDate { get; set; } = endDate;
    public Guid CandidateId { get; set; } = candidateId;
}