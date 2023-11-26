using MediatR;
using RelatedEducation = RecruitBoard.Services.Candidates.Application.Dtos.EducationDto;
using RelatedExperience = RecruitBoard.Services.Candidates.Application.Dtos.ExperienceDto;

namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.CreateCandidate;

public class CreateCandidateCommand : IRequest<CreateCandidateCommandResponse>
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string PersonalData { get; set; }
    public string Skills { get; set; }
    public List<RelatedEducation> Educations { get; set; }
    public List<RelatedExperience> Experiences { get; set; }
}