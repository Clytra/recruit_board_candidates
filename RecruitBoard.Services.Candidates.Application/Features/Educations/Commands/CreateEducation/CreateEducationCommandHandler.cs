using MediatR;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;
using RecruitBoard.Services.Candidates.Application.Exceptions;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Application.Features.Educations.Commands.CreateEducation;

public class CreateEducationCommandHandler(
    IAsyncRepository<Education> educationRepository,
    IAsyncRepository<Candidate> candidateRepository)
    : IRequestHandler<CreateEducationCommand, CreateEducationCommandResponse>
{
    public async Task<CreateEducationCommandResponse> Handle(
        CreateEducationCommand request, CancellationToken cancellationToken)
    {
        CreateEducationCommandResponse response = new();

        var isCandidateExist = await candidateRepository.IsExist(request.CandidateId);

        if (!isCandidateExist)
            throw new NotFoundException(nameof(Candidate), request.CandidateId);
        
        var educationId = Guid.NewGuid();
        
        var education = Education.Create(
            educationId, request.InstitutionName, request.Degree, request.YearOfCompletion,
            request.CandidateId);

        await educationRepository.AddAsync(education);
        response.EducationId = education.Id;

        return response;
    }
}