using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Domain.Events;

public class CandidateCreated(Candidate candidate) : IDomainEvent
{
    public Candidate Candidate { get; } = candidate;
}