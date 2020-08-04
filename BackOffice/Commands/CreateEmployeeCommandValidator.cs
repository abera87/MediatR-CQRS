using FluentValidation;
namespace BackOffice.Commands
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.Phone)
                .MaximumLength(20)
                .NotEmpty();
        }
    }
}