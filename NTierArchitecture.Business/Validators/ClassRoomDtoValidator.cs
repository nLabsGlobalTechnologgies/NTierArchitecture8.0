using FluentValidation;
using NTierArchitecture.Entities.DTOs;

namespace NTierArchitecture.Business.Validators;
public sealed class CreateClassRoomDtoValidator:AbstractValidator<CreateClassRoomDto>
{
    public CreateClassRoomDtoValidator()
    {
        RuleFor(p => p.Name).NotEmpty().NotNull().MinimumLength(3);
    }
}

public sealed class UpdateClassRoomDtoValidator : AbstractValidator<UpdateClassRoomDto>
{
    public UpdateClassRoomDtoValidator()
    {
        RuleFor(p => p.Name).NotEmpty().NotNull().MinimumLength(3);
    }
}
