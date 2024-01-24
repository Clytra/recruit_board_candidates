using MediatR;

namespace RecruitBoard.Services.Candidates.Application.Features.Educations.Commands.CreateEducation;

public abstract class CreateEducationCommand(string institutionName, string degree, int yearOfCompletion, Guid candidateId)
    : IRequest<CreateEducationCommandResponse>
{
    public string InstitutionName { get; set; } = institutionName;
    public string Degree { get; set; } = degree;
    public int YearOfCompletion { get; set; } = yearOfCompletion;
    public Guid CandidateId { get; set; } = candidateId;
}