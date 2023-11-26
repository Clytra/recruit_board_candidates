using System.Text.Json.Serialization;
using RecruitBoard.Services.Candidates.Application.Dtos;

namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.CreateCandidate;

public class CreateCandidateWithDetailsDto
{
    [JsonPropertyName("candidate")]
    public CandidateDto Candidate { get; set; }
    
    [JsonPropertyName("educations")]
    public List<EducationDto> Educations { get; set; }
    
    [JsonPropertyName("experiences")]
    public List<ExperienceDto> Experiences { get; set; }
}