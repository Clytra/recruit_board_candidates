using AutoMapper;
using MediatR;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Queries.GetCandidates;

public class GetCandidatesQueryHandler 
    : IRequestHandler<GetCandidatesQuery, List<CandidatesVm>>
{
    private readonly IAsyncRepository<Candidate> _candidateRepository;
    private readonly IMapper _mapper;

    public GetCandidatesQueryHandler(
        IAsyncRepository<Candidate> candidateRepository,
        IMapper mapper)
    {
        _candidateRepository = candidateRepository;
        _mapper = mapper;
    }
    
    public async Task<List<CandidatesVm>> Handle(
        GetCandidatesQuery request, CancellationToken cancellationToken)
    {
        var candidates = (await _candidateRepository
            .ListAllAsync())
            .OrderBy(x => x.CreatedDate);

        return _mapper.Map<List<CandidatesVm>>(candidates);
    }
}