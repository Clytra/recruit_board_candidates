using AutoMapper;
using MediatR;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;
using RecruitBoard.Services.Candidates.Application.Exceptions;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Queries.GetCandidate;

public class GetCandidateQueryHandler(
    ICandidateRepository candidateRepository,
    IMapper mapper)
    : IRequestHandler<GetCandidateQuery, CandidateDetailsVm>
{
    public async Task<CandidateDetailsVm> Handle(
        GetCandidateQuery request, CancellationToken cancellationToken)
    {
        var candidate = await candidateRepository.GetCandidateWithDetails(request.Id);

        if (candidate == null)
            throw new NotFoundException(nameof(Candidate), request.Id);
        
        return mapper.Map<CandidateDetailsVm>(candidate);
    }
}