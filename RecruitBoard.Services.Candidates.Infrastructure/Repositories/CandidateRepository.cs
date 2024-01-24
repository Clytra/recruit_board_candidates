using Microsoft.EntityFrameworkCore;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Infrastructure.Repositories;

public class CandidateRepository(DataContext context) : BaseRepository<Candidate>(context), ICandidateRepository
{
    public async Task<Candidate?> GetCandidateWithDetails(Guid candidateId)
    {
        var candidate = await _context.Candidates
            .Include(x => x.Educations)
            .Include(x => x.Experiences)
            .Where(x => x.Id == candidateId)
            .FirstOrDefaultAsync();

        return candidate;
    }
}