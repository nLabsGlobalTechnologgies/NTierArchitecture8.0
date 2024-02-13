using Microsoft.EntityFrameworkCore;
using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.DataAccess.Interfaces;
using NTierArchitecture.DataAccess.Services;
using NTierArchitecture.Entities.DTOs;
using NTierArchitecture.Entities.Models;
using System.Linq.Expressions;

namespace NTierArchitecture.DataAccess.Repositories;
public sealed class UserRepository(
    AppDbContext context,
    JwtProvider jwtProvider) : IUserRepository
{
    public AppUser? Get(LoginDto request)
    {
        var user =
            context.Users!
            .FirstOrDefault(p => p.UserName == request.UserNameOrEmail || p.Email == request.UserNameOrEmail);

        if (user is null)  //iş kuralı | business logic
        {
            throw new ArgumentException("Kullanıcı bulunamadı");
        }
        return user;
    }

    public IQueryable<AppUser>? GetAll()
    {
        return context.Users!.AsNoTracking().AsQueryable();
    }

    public AppUser? GetById(Guid id)
    {
        return context.Users!.Find(id);
    }

    public LoginResponseDto Login(LoginDto request)
    {
        var user = UserIsExists(p => p.UserName == request.UserNameOrEmail || p.Email == request.UserNameOrEmail);
        if (user is null)
        {
            throw new ArgumentException("Böyle bir kullanıcı yok");
        }

        var checkPasswordIsTrue = PasswordService.CheckPassword(user, request.Password);

        if (!checkPasswordIsTrue) //iş kuralı | business logic
        {
            throw new ArgumentException("Şifre yanlış");
        }

        return jwtProvider.CreateToken(user, request.RememberMe);
    }

    public AppUser? Register(AppUser request)
    {
        AppUser? user = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            PasswordHash = request.PasswordHash,
            PasswordSalt = request.PasswordSalt,
            Email = request.Email,
            UserName = request.UserName
        };

        context.Add(user);
        context.SaveChanges();

        return user;
    }

    public AppUser? UserIsExists(Expression<Func<AppUser, bool>> predicate)
    {
        return context.Users!.Where(predicate).FirstOrDefault();
    }

    public List<AppUser>? Search(Expression<Func<AppUser, bool>> predicate = default)
    {
        return context.Users!.Where(predicate).ToList();
    }

    public AppUser? Update(AppUser request)
    {
        context.Update(request);
        return request;
    }
}
