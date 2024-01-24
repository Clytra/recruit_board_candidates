using MediatR;

namespace RecruitBoard.Services.Candidates.Application.Features.Educations.Commands.DeleteEducation;

public class DeleteEducationCommand : IRequest
{
    public Guid EducationId { get; init; }
}