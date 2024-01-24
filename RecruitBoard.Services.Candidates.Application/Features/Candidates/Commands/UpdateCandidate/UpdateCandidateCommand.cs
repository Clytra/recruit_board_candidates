using MediatR;
using RelatedEducation = RecruitBoard.Services.Candidates.Application.Dtos.EducationDto;
using RelatedExperience = RecruitBoard.Services.Candidates.Application.Dtos.ExperienceDto;

namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.UpdateCandidate;

public class UpdateCandidateCommand(
    Guid candidateId,
    string firstname,
    string lastname,
    string city,
    string country,
    string personalData,
    string skills,
    List<RelatedEducation> educations,
    List<RelatedExperience> experiences)
    : IRequest
{
    public Guid CandidateId { get; set; } = candidateId;

    public string Firstname { get; set; } = firstname;
    public string Lastname { get; set; } = lastname;
    public string City { get; set; } = city;
    public string Country { get; set; } = country;
    public string PersonalData { get; set; } = personalData;
    public string Skills { get; set; } = skills;
    public List<RelatedEducation> Educations { get; set; } = educations;
    public List<RelatedExperience> Experiences { get; set; } = experiences;
}