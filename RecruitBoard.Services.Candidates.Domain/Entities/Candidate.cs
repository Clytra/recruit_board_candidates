using RecruitBoard.Services.Candidates.Domain.Common;

namespace RecruitBoard.Services.Candidates.Domain.Entities;

public class Candidate : AuditableEntity
{
    public Guid Id { get; private set; }
    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public string City { get; private set; }
    public string Country { get; private set; }
    public string PersonalData { get; private set; }
    public string Skills { get; private set; }
    
    public List<Education> Educations { get; set; }
    public List<Experience> Experiences { get; set; }


    private Candidate() { }
    
    private Candidate(Guid id, string firstname, string lastname, string city, 
        string country, string personalData, string skills)
    {
        Id = id;
        Firstname = firstname ?? throw new ArgumentNullException(nameof(firstname));
        Lastname = lastname ?? throw new ArgumentNullException(nameof(lastname));
        City = city ?? throw new ArgumentNullException(nameof(city));
        Country = country ?? throw new ArgumentNullException(nameof(country));
        PersonalData = personalData ?? throw new ArgumentNullException(nameof(personalData));
        Skills = skills ?? throw new ArgumentNullException(nameof(skills));
        Educations = new List<Education>();
        Experiences = new List<Experience>();
    }

    public static Candidate Create(Guid id, string firstname, string lastname, string city, 
        string country, string personalData, string skills, List<Education> educations,
        List<Experience> experiences)
    {
        Candidate candidate = new(id, firstname, lastname, city, country, personalData, skills);

        candidate.Educations = educations;
        candidate.Experiences = experiences;
        
        //TODO: Add Event

        return candidate;
    }
}