using CarBook.Application.Features.Mediator.Commands.CommetCommands;
using FluentValidation;

namespace Carbook.Application.Validations.Comments;

public class CreateCommentValidation : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentValidation()
    {
        RuleFor(x=>x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x=>x.Name).MinimumLength(3).WithMessage("Name must be at least 3 characters long.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
        RuleFor(x=>x.Description).MaximumLength(50).WithMessage("Description must be less than 50 characters long.");
    }
}