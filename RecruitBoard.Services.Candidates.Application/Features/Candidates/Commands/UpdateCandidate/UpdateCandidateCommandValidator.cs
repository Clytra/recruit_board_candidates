using FluentValidation;

namespace RecruitBoard.Services.Candidates.Application.Features.Candidates.Commands.UpdateCandidate;

public class UpdateCandidateCommandValidator : AbstractValidator<UpdateCandidateCommand>
{
    public UpdateCandidateCommandValidator()
    {
        RuleFor(x => x.Firstname)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
        RuleFor(x => x.Lastname)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
    }
}