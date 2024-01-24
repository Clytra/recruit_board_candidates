namespace RecruitBoard.Services.Candidates.Domain.Entities;

public class Education 
{
    public Guid Id { get; private set; }
    public string InstitutionName { get; private set; }
    public string Degree { get; private set; }
    public int YearOfCompletion { get; private set; }
    
    public Guid CandidateID { get; private set; }
    public Candidate Candidate { get; set; }

    
    private Education() { }
    
    private Education(Guid id, string institutionName, string degree, int yearOfCompletion, 
        Guid candidateId)
    {
        Id = id;
        InstitutionName = institutionName;
        Degree = degree;
        YearOfCompletion = yearOfCompletion;
        CandidateID = candidateId;
    }
    
    public static Education Create(
        Guid id, string institutionName, string degree, int yearOfCompletion, Guid candidateId)
    {
        Education education = new(id, institutionName, degree, yearOfCompletion, candidateId);

        return education;
    }
}