using AutoMapper;
using NTierArchitecture.Business.Interfaces;
using NTierArchitecture.Business.Validators;
using NTierArchitecture.DataAccess.Interfaces;
using NTierArchitecture.DataAccess.Services;
using NTierArchitecture.Entities.DTOs;
using NTierArchitecture.Entities.Models;
using System.Linq.Expressions;

namespace NTierArchitecture.Business.Managers;
public sealed class UserManager(
    IUserRepository userRepository,
    JwtProvider jwtProvider,
    IMapper mapper) : IUserService
{
    public IQueryable<AppUser>? GetAll()
    {
        IQueryable<AppUser>? users = userRepository.GetAll();
        users!.ToList();

        return users;
    }

    public AppUser? GetById(Guid id)
    {
        var result = userRepository.GetById(id);
        return result;
    }

    public LoginResponseDto? Login(LoginDto request)
    {
        var validator = new LoginDtoValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            throw new ArgumentException(result.Errors[0].ErrorMessage);
        }

        var userResult = userRepository.Login(request);
        if (userResult is null) // burada userResult kontrolü yapılmalı
        {
            throw new ArgumentException("Kullanıcı girişi başarısız");
        }

        var loginResponse = new LoginResponseDto
        {
            AccessToken = userResult.AccessToken,
            UserId = userResult.UserId
        };

        return new LoginResponseDto{ AccessToken = loginResponse.AccessToken, UserId = loginResponse.UserId };
    }

    public AppUser? Register(RegisterDto request)
    {
        if (request.Password != request.RePassword)
        {
            throw new ArgumentException("Parolalar eşleşmiyor lütfen parola ve parola tekrarını aynı yazınız");
        }

        var validator = new RegisterDtoValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            throw new ArgumentException(result.Errors[0].ErrorMessage);
        }

        var checkUserNameOrEmail = userRepository.UserIsExists(p => p.UserName == request.UserName || p.Email == request.Email);
        if (checkUserNameOrEmail is not null)
        {
            throw new ArgumentException("Kullanıcı adı veya email daha önce kullanılmış");
        }

        byte[] passwordSalt, passwordHash;

        PasswordService.CreatePassword(request.Password, out passwordSalt, out passwordHash);
        AppUser user = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = request.UserName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
        };
        var userResult = userRepository.Register(user);
        if (userResult is null)
        {
            throw new ArgumentException("Hata");
        }
        return userResult;
    }

    public AppUser? UserIsExists(Expression<Func<AppUser, bool>> predicate)
    {
        var result = userRepository.UserIsExists(predicate);
        if (result is null)
        {
            throw new ArgumentException("Kullanıcı bulunamadı");
        }
        return result;
    }

    public List<AppUser>? Search(Expression<Func<AppUser, bool>> predicate = null)
    {
        return userRepository.Search(predicate);
    }

    public AppUser? Update(UpdateUserDto request)
    {
        throw new NotImplementedException();
    }
}
