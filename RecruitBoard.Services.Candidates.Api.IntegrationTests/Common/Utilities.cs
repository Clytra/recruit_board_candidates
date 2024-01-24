using RecruitBoard.Services.Candidates.Domain.Entities;
using RecruitBoard.Services.Candidates.Infrastructure;

namespace RecruitBoard.Services.Candidates.Api.IntegrationTests.Common;

public abstract class Utilities
{
    public static void InitializeDbForTests(DataContext context)
    {
        var candidateId = Guid.NewGuid();

        var candidate = Candidate.Create(
            candidateId, "Jan", "Nowak", "Kraków", "Polska",
            "Pasjonat programowania", "Azure", new List<Education>
            { Education.Create(Guid.NewGuid(), "Politechnika Krakowska",
                "magisterskie", 2020, candidateId) },
            new List<Experience> { Experience.Create(Guid.NewGuid(), 
                "Xebia Polska", ".NET Developer", new DateTime(
                    2015, 6, 1), null, candidateId) });

        context.Candidates.Add(candidate);
        context.SaveChangesAsync(); 
    }
}