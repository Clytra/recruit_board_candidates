using RecruitBoard.Services.Candidates.Domain.Entities;
using Xunit;

namespace RecruitBoard.Services.Candidates.Domain.UnitTests.Entities;

public class CandidateTests
{
    private static readonly Guid Id = Guid.NewGuid();
    private const string? Firstname = "Jan";
    private const string Lastname = "Nowak";
    private const string City = "Kraków";
    private const string Country = "Polska";
    private const string PersonalData = "Pasjonat programowania";
    private const string Skills = "Azure";
    private const string InstitutionName = "Politechnika Krakowska";
    private const string Degree = "magisterskie";
    private const int YearOfCompletion = 2015;
    private const string CompanyName = "Xebia";
    private const string Position = ".NET Developer";
    private static readonly DateTime StartDate = new DateTime(2015, 6, 1);
    
    [Fact]
    public void Constructor_WithValidParameters_InitializesProperties()
    {
        var experiences = new List<Experience>{
            Experience.Create(
                Guid.NewGuid(), CompanyName, Position, StartDate, null, Id)};
        var education = Education.Create(
            Guid.NewGuid(), InstitutionName, Degree, YearOfCompletion, Id);
        
        var candidate = Candidate.Create(
            Id, Firstname, Lastname, City, Country, PersonalData, Skills,
            [education], experiences);

        Assert.Equal(Firstname, candidate.Firstname);
        Assert.Equal(Lastname, candidate.Lastname);
        Assert.Equal(PersonalData, candidate.PersonalData);
        Assert.Equal(experiences, candidate.Experiences);
    }
    
    [Fact]
    public void Constructor_WithNullFirstname_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => 
            Candidate.Create(
                Guid.NewGuid(), null, Lastname, City, Country, PersonalData, Skills,
                [], new List<Experience>()));
    }
}