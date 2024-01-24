using RecruitBoard.Services.Candidates.Application.Responses;

namespace RecruitBoard.Services.Candidates.Application.Features.Educations.Commands.CreateEducation;

public class CreateEducationCommandResponse : BaseResponse
{
    public CreateEducationCommandResponse() : base() { }
    public Guid EducationId { get; set; }
}