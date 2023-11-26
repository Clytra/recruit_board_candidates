using RecruitBoard.Services.Candidates.Application.Features.Candidates.Queries.GetCandidate;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;

public interface ICandidateRepository 
    : IAsyncRepository<Candidate>
{
    Task<CandidateDetailsVm> GetCandidateWithDetails(Guid candidateId);
}