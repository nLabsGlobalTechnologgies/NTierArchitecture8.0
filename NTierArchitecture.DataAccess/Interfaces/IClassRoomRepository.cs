using NTierArchitecture.Entities.Models;
using System.Linq.Expressions;

namespace NTierArchitecture.DataAccess.Interfaces;
public interface IClassRoomRepository
{
    void Create(ClassRoom classRoom);
    void Update(ClassRoom classRoom);
    void DeleteById(Guid Id);
    List<ClassRoom> GetAll();
    ClassRoom? GetClassRoomById(Guid Id);
    bool Any(Expression<Func<ClassRoom, bool>> predicate);
}
