using NTierArchitecture.Entities.DTOs;
using NTierArchitecture.Entities.Models;
using System.Linq.Expressions;

namespace NTierArchitecture.DataAccess.Interfaces;
public interface IUserRepository
{
    AppUser? Register(AppUser request);
    LoginResponseDto? Login(LoginDto request);
    AppUser? Update(AppUser request);
    IQueryable<AppUser>? GetAll();
    AppUser? GetById(Guid id);
    AppUser? Get(LoginDto request);
    AppUser? UserIsExists(Expression<Func<AppUser, bool>> predicate);
    List<AppUser>? Search(Expression<Func<AppUser, bool>> predicate = default);
}
