using FluentValidation;

namespace Magical.Application.Profiles.Commands.CreateProfile
{
    public class CreateProfileCommandValidator : AbstractValidator<CreateProfileCommand>
    {
        public CreateProfileCommandValidator()
        {
            RuleFor(x => x.UserName)
                .MaximumLength(50).NotEmpty();

            RuleFor(x => x.Email).NotEmpty()
                .MaximumLength(100).EmailAddress();
        }
    }
}
