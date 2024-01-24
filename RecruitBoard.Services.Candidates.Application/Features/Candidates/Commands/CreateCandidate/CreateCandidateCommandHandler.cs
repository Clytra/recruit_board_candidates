using MediatR;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.CreateCandidate;

public class CreateCandidateCommandHandler(IAsyncRepository<Candidate> candidateRepository)
    : IRequestHandler<CreateCandidateCommand, CreateCandidateCommandResponse>
{
    public async Task<CreateCandidateCommandResponse> Handle(
        CreateCandidateCommand request, CancellationToken cancellationToken)
    {
        CreateCandidateCommandResponse response = new();
        
        var validator = new CreateCandidateCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
        {
            response.Success = false;
            response.ValidationErrors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                response.ValidationErrors.Add(error.ErrorMessage);
            }
        }

        var candidateId = Guid.NewGuid();
        if (!response.Success) return response;
        
        var educations = request.Educations.Select(edu => 
            Education.Create(
                Guid.NewGuid(), edu.InstitutionName, edu.Degree, edu.YearOfCompletion, candidateId));
            
        var experiences = request.Experiences.Select(exp => 
            Experience.Create(
                Guid.NewGuid(), exp.CompanyName, exp.Position, exp.StartDate, exp.EndDate, candidateId));
            
        var candidate = Candidate.Create(candidateId, request.Firstname, request.Lastname, 
            request.City, request.Country, request.PersonalData, request.Skills,
            educations.ToList(), experiences.ToList());
            
        await candidateRepository.AddAsync(candidate);
        response.CandidateId = candidate.Id;

        return response;
    }
}