namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Queries.GetCandidates;

public class CandidatesVm(string firstname, string lastname, string city, string country)
{
    public string Firstname { get; set; } = firstname;
    public string Lastname { get; set; } = lastname;
    public string City { get; set; } = city;
    public string Country { get; set; } = country;
}