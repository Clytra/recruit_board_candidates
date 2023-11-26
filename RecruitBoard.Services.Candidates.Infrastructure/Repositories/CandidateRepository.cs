using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;
using RecruitBoard.Services.Candidates.Application.Features.Candidates.Queries.GetCandidate;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Infrastructure.Repositories;

public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
{
    private readonly IMapper _mapper;

    public CandidateRepository(
        DataContext context,
        IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public async Task<CandidateDetailsVm> GetCandidateWithDetails(Guid candidateId)
    {
        var candidate = await _context.Candidates
            .Include(x => x.Educations)
            .Include(x => x.Experiences)
            .Where(x => x.Id == candidateId)
            .FirstOrDefaultAsync();

        return _mapper.Map<CandidateDetailsVm>(candidate);
    }
}