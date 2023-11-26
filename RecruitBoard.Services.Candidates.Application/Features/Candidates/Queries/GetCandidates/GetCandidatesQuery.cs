using MediatR;

namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Queries.GetCandidates;

public class GetCandidatesQuery : IRequest<List<CandidatesVm>> { }