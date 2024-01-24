using MediatR;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;
using RecruitBoard.Services.Candidates.Application.Exceptions;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.DeleteCandidate;

public class DeleteCandidateCommandHandler(IAsyncRepository<Candidate> candidateRepository)
    : IRequestHandler<DeleteCandidateCommand>
{
    public async Task<Unit> Handle(
        DeleteCandidateCommand request, CancellationToken cancellationToken)
    {
        var candidateToDelete = await candidateRepository
            .GetByIdAsync(request.CandidateId);

        if (candidateToDelete == null)
            throw new NotFoundException(nameof(Candidate), request.CandidateId);
        
        await candidateRepository.DeleteAsync(candidateToDelete);

        return Unit.Value;
    }
}