using NTierArchitecture.Entities.DTOs;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Business.Interfaces;
public interface IClassRoomService
{
    string Create(CreateClassRoomDto request);
    string Update(UpdateClassRoomDto request);
    string DeleteById(Guid id);
    List<ClassRoom> GetAll();
}
