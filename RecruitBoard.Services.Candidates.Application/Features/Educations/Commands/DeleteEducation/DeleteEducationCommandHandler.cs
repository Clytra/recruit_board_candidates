using MediatR;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;
using RecruitBoard.Services.Candidates.Application.Exceptions;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Application.Features.Educations.Commands.DeleteEducation;

public class DeleteEducationCommandHandler(IAsyncRepository<Education> educationRepository)
    : IRequestHandler<DeleteEducationCommand>
{
    public async Task<Unit> Handle(
        DeleteEducationCommand request, CancellationToken cancellationToken)
    {
        var educationToDelete = await educationRepository
            .GetByIdAsync(request.EducationId);

        if (educationToDelete == null)
            throw new NotFoundException(nameof(Education), request.EducationId);

        await educationRepository.DeleteAsync(educationToDelete);

        return Unit.Value;
    }
}