using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Domain.Events;

public class CandidateCreated : IDomainEvent
{
    public Candidate Candidate { get; }

    public CandidateCreated(Candidate candidate)
        => Candidate = candidate;
}