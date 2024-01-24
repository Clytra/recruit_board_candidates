using AutoMapper;
using RecruitBoard.Services.Candidates.Application.Dtos;
using RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.UpdateCandidate;
using RecruitBoard.Services.Candidates.Application.Features.Candidates.Queries.GetCandidate;
using RecruitBoard.Services.Candidates.Application.Features.Candidates.Queries.GetCandidates;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Candidate, CandidatesVm>();
        
        CreateMap<EducationDto, Education>()
            .ForMember(dest => dest.Id,
                opt => opt.Ignore())
            .ForMember(dest => dest.CandidateID,
                opt => opt.Ignore())
            .ForMember(dest => dest.Candidate,
                opt => opt.Ignore())
            .ReverseMap();
        
        CreateMap<ExperienceDto, Experience>()
            .ForMember(dest => dest.Id,
                opt => opt.Ignore())
            .ForMember(dest => dest.CandidateID,
                opt => opt.Ignore())
            .ForMember(dest => dest.Candidate,
                opt => opt.Ignore())
            .ReverseMap();
        
        CreateMap<Candidate, CandidateDetailsVm>()
            .ForMember(dest => dest.Educations, 
                opt => 
                    opt.MapFrom(src => src.Educations))
            .ForMember(dest => dest.Experiences, 
                opt => 
                    opt.MapFrom(src => src.Experiences));

        CreateMap<UpdateCandidateCommand, Candidate>()
            .ForMember(dest => dest.Educations,
                opt =>
                    opt.MapFrom(src => src.Educations))
            .ForMember(dest => dest.Experiences,
                opt =>
                    opt.MapFrom(src => src.Experiences))
            .ForMember(dest => dest.Id,
                opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy,
                opt => opt.Ignore())
            .ForMember(dest => dest.CreatedDate,
                opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy,
                opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedDate,
                opt => opt.Ignore())
            .ForMember(dest => dest.Deleted,
                opt => opt.Ignore());
    }
}