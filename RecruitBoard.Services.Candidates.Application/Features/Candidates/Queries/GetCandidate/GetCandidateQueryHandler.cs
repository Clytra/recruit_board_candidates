using AutoMapper;
using MediatR;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;
using RecruitBoard.Services.Candidates.Application.Exceptions;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Queries.GetCandidate;

public class GetCandidateQueryHandler 
    : IRequestHandler<GetCandidateQuery, CandidateDetailsVm>
{
    private readonly ICandidateRepository _candidateRepository;
    private readonly IMapper _mapper;

    public GetCandidateQueryHandler(
        ICandidateRepository candidateRepository,
        IMapper mapper)
    {
        _candidateRepository = candidateRepository;
        _mapper = mapper;
    }
    
    public async Task<CandidateDetailsVm> Handle(
        GetCandidateQuery request, CancellationToken cancellationToken)
    {
        var candidate = await _candidateRepository.GetCandidateWithDetails(request.Id);

        if (candidate == null)
            throw new NotFoundException(nameof(Candidate), request.Id);
        
        return _mapper.Map<CandidateDetailsVm>(candidate);
    }
}