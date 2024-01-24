namespace RecruitBoard.Services.Candidates.Domain.Entities;

public class Experience 
{
    public Guid Id { get; private set; }
    public string CompanyName { get; private set; }
    public string Position { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    
    public Guid CandidateID { get; private set; }
    public Candidate Candidate { get; set; }

    
    private Experience() { }
    
    private Experience(Guid id, string companyName, string position, DateTime startDate, 
        DateTime? endDate, Guid candidateId)
    {
        Id = id;
        CompanyName = companyName;
        Position = position;
        StartDate = startDate;
        EndDate = endDate;
        CandidateID = candidateId;
    }

    public static Experience Create(Guid id, string companyName, string position, DateTime startDate, 
        DateTime? endDate, Guid candidateId)
    {
        Experience experience = new(id, companyName, position, startDate, endDate, candidateId);

        return experience;
    }
}