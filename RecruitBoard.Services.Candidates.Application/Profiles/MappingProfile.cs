using AutoMapper;
using RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.UpdateCandidate;
using RecruitBoard.Services.Candidates.Application.Features.Candidates.Queries.GetCandidate;
using RecruitBoard.Services.Candidates.Application.Features.Candidates.Queries.GetCandidates;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Candidate, CandidatesVm>().ReverseMap();
        CreateMap<Candidate, CandidateDetailsVm>();

        CreateMap<Candidate, UpdateCandidateCommand>().ReverseMap();
    }
}