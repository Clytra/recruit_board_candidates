using AutoMapper;
using MediatR;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.CreateCandidate;

public class CreateCandidateCommandHandler 
    : IRequestHandler<CreateCandidateCommand, CreateCandidateCommandResponse>
{
    private readonly IAsyncRepository<Candidate> _candidateRepository;
    private readonly IMapper _mapper;

    public CreateCandidateCommandHandler(
        IAsyncRepository<Candidate> candidateRepository,
        IMapper mapper)
    {
        _candidateRepository = candidateRepository;
        _mapper = mapper;
    }
    
    public async Task<CreateCandidateCommandResponse> Handle(
        CreateCandidateCommand request, CancellationToken cancellationToken)
    {
        CreateCandidateCommandResponse response = new();
        
        var validator = new CreateCandidateCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

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
        if (response.Success)
        {
            var candidate = Candidate.Create(candidateId, request.Firstname, request.Lastname, 
                request.City, request.Country, request.PersonalData, request.Skills);
            
            request.Educations.ForEach(edu =>
            {
                Education education = Education.Create(Guid.NewGuid(), edu.InstitutionName, edu.Degree,
                    edu.YearOfCompletion, candidateId);
                candidate.Educations.Add(education);
            });
            
            request.Experiences.ForEach(exp =>
            {
                Experience experience = Experience.Create(Guid.NewGuid(), exp.CompanyName, exp.Position, 
                    exp.StartDate, exp.EndDate, candidateId);
                candidate.Experiences.Add(experience);
            });
            
            await _candidateRepository.AddAsync(candidate);
            response.Candidate = _mapper.Map<CreateCandidateDto>(candidate);
        }
        
        return response;
    }
}