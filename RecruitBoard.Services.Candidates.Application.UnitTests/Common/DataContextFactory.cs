using Microsoft.EntityFrameworkCore;
using Moq;
using RecruitBoard.Services.Candidates.Domain.Entities;
using RecruitBoard.Services.Candidates.Infrastructure;

namespace RecruitBoard.Services.Candidates.Application.UnitTests.Common;

public static class DataContextFactory
{
    public static Mock<DataContext> Create()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        var mock = new Mock<DataContext>(options) { CallBase = true };
        var context = mock.Object;

        context.Database.EnsureCreated();

        #region Entities

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

        #endregion

        return mock;
    }

    public static void Destroy(DataContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}