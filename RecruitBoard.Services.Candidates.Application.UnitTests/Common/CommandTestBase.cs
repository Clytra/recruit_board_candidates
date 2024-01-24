using Moq;
using RecruitBoard.Services.Candidates.Infrastructure;

namespace RecruitBoard.Services.Candidates.Application.UnitTests.Common;

public class CommandTestBase : IDisposable
{
    private readonly DataContext _context;

    public CommandTestBase()
    {
        Mock<DataContext> contextMock = DataContextFactory.Create();
        _context = contextMock.Object;
    }
    
    public void Dispose()
    {
        DataContextFactory.Destroy(_context);
    }
}