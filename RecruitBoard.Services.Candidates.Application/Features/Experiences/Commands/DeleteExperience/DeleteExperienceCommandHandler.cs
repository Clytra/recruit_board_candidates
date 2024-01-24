using MediatR;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;
using RecruitBoard.Services.Candidates.Application.Exceptions;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Application.Features.Experiences.Commands.DeleteExperience;

public class DeleteExperienceCommandHandler(IAsyncRepository<Experience> experienceRepository)
    : IRequestHandler<DeleteExperienceCommand>
{
    public async Task<Unit> Handle(
        DeleteExperienceCommand request, CancellationToken cancellationToken)
    {
        var experienceToDelete = await experienceRepository
            .GetByIdAsync(request.ExperienceId);

        if (experienceToDelete == null)
            throw new NotFoundException(nameof(Experience), request.ExperienceId);

        await experienceRepository.DeleteAsync(experienceToDelete);

        return Unit.Value;
    }
}