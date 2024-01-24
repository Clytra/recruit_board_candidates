using RecruitBoard.Services.Candidates.Application.Responses;

namespace RecruitBoard.Services.Candidates.Application.Features.Experiences.Commands.CreateExperience;

public class CreateExperienceCommandResponse : BaseResponse
{
    public CreateExperienceCommandResponse() : base() { }
    public Guid ExperienceId { get; set; }
}