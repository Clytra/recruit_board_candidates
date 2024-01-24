using MediatR;

namespace RecruitBoard.Services.Candidates.Application.Features.Experiences.Commands.DeleteExperience;

public class DeleteExperienceCommand : IRequest
{
    public Guid ExperienceId { get; init; }
}