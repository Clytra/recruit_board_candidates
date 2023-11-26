using AutoMapper;
using MediatR;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;
using RecruitBoard.Services.Candidates.Application.Exceptions;
using RecruitBoard.Services.Candidates.Domain.Entities;
using ValidationException = RecruitBoard.Services.Candidates.Application.Exceptions.ValidationException;

namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.UpdateCandidate;

public class UpdateCandidateCommandHandler 
    : IRequestHandler<UpdateCandidateCommand>
{
    private readonly IAsyncRepository<Candidate> _candidateRepository;
    private readonly IMapper _mapper;

    public UpdateCandidateCommandHandler(
        IAsyncRepository<Candidate> candidateRepository,
        IMapper mapper)
    {
        _candidateRepository = candidateRepository;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(
        UpdateCandidateCommand request, CancellationToken cancellationToken)
    {
        Candidate candidateToUpdate = await _candidateRepository
            .GetByIdAsync(request.CandidateId);

        if (candidateToUpdate == null)
            throw new NotFoundException(nameof(Candidate), request.CandidateId);

        var validator = new UpdateCandidateCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);

        _mapper.Map(request, candidateToUpdate, 
            typeof(UpdateCandidateCommand), typeof(Candidate));

        await _candidateRepository.UpdateAsync(candidateToUpdate);

        return Unit.Value;
    }
}