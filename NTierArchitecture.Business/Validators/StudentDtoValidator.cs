using FluentValidation;
using NTierArchitecture.Entities.DTOs;

namespace NTierArchitecture.Business.Validators;
public sealed class CreateStudentDtoValidator : AbstractValidator<CreateStudentDto>
{
    public CreateStudentDtoValidator()
    {
        RuleFor(p => p.FirstName).NotEmpty().NotNull().MinimumLength(3);
        RuleFor(p => p.LastName).NotEmpty().NotNull().MinimumLength(3);
        RuleFor(p => p.Number).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(p => p.IdCardNumber)
            .NotEmpty()
            .NotNull()
            .MinimumLength(11)
            .MaximumLength(11)
            .Matches("0-9");
    }
}

public sealed class UpdateStudentDtoValidator : AbstractValidator<UpdateStudentDto>
{
    public UpdateStudentDtoValidator()
    {
        RuleFor(p => p.FirstName).NotEmpty().NotNull().MinimumLength(3);
        RuleFor(p => p.LastName).NotEmpty().NotNull().MinimumLength(3);
        RuleFor(p => p.Number).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(p => p.IdCardNumber).NotEmpty().NotNull().MinimumLength(11).MaximumLength(11).Matches("0-9");
    }
}
