using NTierArchitecture.Entities.DTOs;
using NTierArchitecture.Entities.Models;
using System.Linq.Expressions;

namespace NTierArchitecture.Business.Interfaces;
public interface IUserService
{
    AppUser? Register(RegisterDto request);
    LoginResponseDto? Login(LoginDto request);
    AppUser? Update(UpdateUserDto request);
    IQueryable<AppUser>? GetAll();
    AppUser? GetById(Guid id);

    AppUser? UserIsExists(Expression<Func<AppUser, bool>> predicate);
    List<AppUser>? Search(Expression<Func<AppUser, bool>> predicate = default);
}
