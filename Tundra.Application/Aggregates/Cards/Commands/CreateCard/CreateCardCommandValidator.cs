using FluentValidation;

namespace Tundra.Application.Aggregates.Cards.Commands.CreateCard
{
    public class CreateCardCommandValidator : AbstractValidator<CreateCardCommand>
    {
        public CreateCardCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .Matches("[a-zA-Z0-9]");

            RuleFor(x => x.Description).NotEmpty()
                .Matches("[a-zA-Z0-9]");
        }
    }
}
