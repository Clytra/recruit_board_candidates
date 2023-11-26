using FluentValidation;

namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.CreateCandidate;

public class CreateCandidateCommandValidator 
    : AbstractValidator<CreateCandidateCommand>
{
    public CreateCandidateCommandValidator()
    {
        RuleFor(x => x.Firstname)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
        RuleFor(x => x.Lastname)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
    }
}