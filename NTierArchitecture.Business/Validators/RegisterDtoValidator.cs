using FluentValidation;
using NTierArchitecture.Entities.DTOs;

namespace NTierArchitecture.Business.Validators;
public sealed class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(p => p.FirstName).NotEmpty().WithMessage("Geçerli bir isim girin");
        RuleFor(p => p.FirstName).NotNull().WithMessage("Geçerli bir isim girin");
        RuleFor(p => p.FirstName).MinimumLength(3).WithMessage("İsim alanı en az 3 karakter olmalıdır");
        RuleFor(p => p.LastName).NotEmpty().WithMessage("Geçerli bir soyad girin");
        RuleFor(p => p.LastName).NotNull().WithMessage("Geçerli bir soyad girin");
        RuleFor(p => p.LastName).MinimumLength(3).WithMessage("Soyad alanı en az 3 karakter olmalıdır");
        RuleFor(p => p.UserName).NotEmpty().WithMessage("Geçerli bir kullanıcı adı girin");
        RuleFor(p => p.UserName).NotNull().WithMessage("Geçerli bir kullanıcı adı girin");
        RuleFor(p => p.UserName).MinimumLength(3).WithMessage("Kullanıcı adı alanı en az 3 karakter olmalıdır");
        RuleFor(p => p.Email).NotEmpty().WithMessage("Geçerli bir mail adresi girin");
        RuleFor(p => p.Email).NotNull().WithMessage("Geçerli bir mail adresi girin");
        RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli bir mail adresi girin");
        RuleFor(p => p.Email).MinimumLength(3).WithMessage("Mail adresi alanı en az 3 karakter olmalıdır");
        RuleFor(p => p.Password).NotEmpty().WithMessage("Geçerli bir şifre girin");
        RuleFor(p => p.Password).NotNull().WithMessage("Geçerli bir şifre girin");
        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifreniz en az 1 adet büyük harf içermelidir");
        RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifreniz en az 1 adet küçük harf içermelidir");
        RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifreniz en az 1 adet rakam içermelidir");
        RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifreniz en az 1 adet özel karakter içermelidir");
    }
}
