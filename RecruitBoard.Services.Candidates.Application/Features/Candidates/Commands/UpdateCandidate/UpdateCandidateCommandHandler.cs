using AutoMapper;
using MediatR;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;
using RecruitBoard.Services.Candidates.Application.Features.Candidates.Queries.GetCandidates;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.UpdateCandidate;

public class GetCandidatesQueryHandler(
    IAsyncRepository<Candidate> candidateRepository,
    IMapper mapper)
    : IRequestHandler<GetCandidatesQuery, List<CandidatesVm>>
{
    public async Task<List<CandidatesVm>> Handle(
        GetCandidatesQuery request, CancellationToken cancellationToken)
    {
        var candidates = (await candidateRepository
                .ListAllAsync())
            .OrderBy(x => x.CreatedDate);

        return mapper.Map<List<CandidatesVm>>(candidates);
    }
}