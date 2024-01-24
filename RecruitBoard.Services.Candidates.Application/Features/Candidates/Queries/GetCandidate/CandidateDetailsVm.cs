using RecruitBoard.Services.Candidates.Application.Dtos;

namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Queries.GetCandidate;

public class CandidateDetailsVm
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string PersonalData { get; set; }
    public string Skills { get; set; }
    
    public List<EducationDto> Educations { get; set; }
    public List<ExperienceDto> Experiences { get; set; }
}