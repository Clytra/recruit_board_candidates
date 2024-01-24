using RecruitBoard.Services.Candidates.Application.Responses;

namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.CreateCandidate;

public class CreateCandidateCommandResponse : BaseResponse
{
    public CreateCandidateCommandResponse() : base() { }
    public Guid CandidateId { get; set; }
}