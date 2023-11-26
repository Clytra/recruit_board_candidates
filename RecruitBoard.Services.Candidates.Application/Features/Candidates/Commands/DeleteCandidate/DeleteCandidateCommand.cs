using MediatR;

namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.DeleteCandidate;

public class DeleteCandidateCommand : IRequest
{
    public Guid CandidateId { get; set; }
}