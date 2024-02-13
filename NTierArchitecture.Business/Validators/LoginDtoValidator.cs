using FluentValidation;
using NTierArchitecture.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Validators;
public sealed class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(p => p.UserNameOrEmail).NotEmpty().WithMessage("Geçerli bir kullanıcı adı ya da mail adresi girin");
        RuleFor(p => p.UserNameOrEmail).NotNull().WithMessage("Geçerli bir kullanıcı adı ya da mail adresi girin");
        RuleFor(p => p.UserNameOrEmail).MinimumLength(3).WithMessage("Kullanıcı adı|mail adresi alanı en az 3 karakter olmalıdır");
        RuleFor(p => p.Password).NotEmpty().WithMessage("Geçerli bir şifre girin");
        RuleFor(p => p.Password).NotNull().WithMessage("Geçerli bir şifre girin");
        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifreniz en az 1 adet büyük harf içermelidir");
        RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifreniz en az 1 adet küçük harf içermelidir");
        RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifreniz en az 1 adet rakam içermelidir");
        RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifreniz en az 1 adet özel karakter içermelidir");
    }
}
