using AutoMapper;
using MediatR;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;
using RecruitBoard.Services.Candidates.Application.Exceptions;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.DeleteCandidate;

public class DeleteCandidateCommandHandler 
    : IRequestHandler<DeleteCandidateCommand>
{
    private readonly IAsyncRepository<Candidate> _candidateRepository;
    private readonly IMapper _mapper;

    public DeleteCandidateCommandHandler(
        IAsyncRepository<Candidate> candidateRepository,
        IMapper mapper)
    {
        _candidateRepository = candidateRepository;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(
        DeleteCandidateCommand request, CancellationToken cancellationToken)
    {
        var candidateToDelete = await _candidateRepository
            .GetByIdAsync(request.CandidateId);

        if (candidateToDelete == null)
            throw new NotFoundException(nameof(Candidate), request.CandidateId);
        
        await _candidateRepository.DeleteAsync(candidateToDelete);

        return Unit.Value;
    }
}