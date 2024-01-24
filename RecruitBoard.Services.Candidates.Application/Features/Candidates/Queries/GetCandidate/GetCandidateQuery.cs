using MediatR;

namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Queries.GetCandidate;

public class GetCandidateQuery : IRequest<CandidateDetailsVm>
{
    public Guid Id { get; init; }
}