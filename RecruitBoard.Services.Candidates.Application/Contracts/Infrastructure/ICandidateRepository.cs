using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;

public interface ICandidateRepository 
    : IAsyncRepository<Candidate>
{
    Task<Candidate?> GetCandidateWithDetails(Guid candidateId);
}