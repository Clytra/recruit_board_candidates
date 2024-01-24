using MediatR;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;
using RecruitBoard.Services.Candidates.Application.Exceptions;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Application.Features.Experiences.Commands.CreateExperience;

public class CreateExperienceCommandHandler(
    IAsyncRepository<Experience> experienceRepository,
    IAsyncRepository<Candidate> candidateRepository)
    : IRequestHandler<CreateExperienceCommand, CreateExperienceCommandResponse>
{
    public async Task<CreateExperienceCommandResponse> Handle(
        CreateExperienceCommand request, CancellationToken cancellationToken)
    {
        CreateExperienceCommandResponse response = new();

        var isCandidateExist = await candidateRepository.IsExist(request.CandidateId);

        if (!isCandidateExist)
            throw new NotFoundException(nameof(Candidate), request.CandidateId);

        var experienceId = Guid.NewGuid();

        var experience = Experience.Create(
            experienceId, request.CompanyName, request.Position, request.StartDate,
            request.EndDate, request.CandidateId);

        await experienceRepository.AddAsync(experience);
        response.ExperienceId = experience.Id;

        return response;
    }
}