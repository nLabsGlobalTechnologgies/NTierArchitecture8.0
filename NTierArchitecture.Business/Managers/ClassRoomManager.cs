using AutoMapper;
using FluentValidation.Results;
using NTierArchitecture.Business.Interfaces;
using NTierArchitecture.Business.Validators;
using NTierArchitecture.DataAccess.Interfaces;
using NTierArchitecture.Entities.DTOs;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Business.Managers;
public sealed class ClassRoomManager(IClassRoomRepository classRoomRepository, IMapper mapper) : IClassRoomService
{
    public string Create(CreateClassRoomDto request)
    {
        CreateClassRoomDtoValidator validator = new();
        ValidationResult result = validator.Validate(request);
        if (!result.IsValid)
        {
            throw new ArgumentException(string.Join(" ", result.Errors.Select(s => s.ErrorMessage)));
        }

        bool isNameExists = classRoomRepository.Any(p => p.Name == request.Name);

        if (!isNameExists)
        {
            throw new ArgumentException("Bu isme sahip sınıf daha önceden kaydedilmiş!");
        }

        ClassRoom classRoom = new()
        {
            Name = request.Name,
        };
        classRoomRepository.Create(classRoom);

        return "Kayıt işlemi başarıyla tamamlandı";
    }

    public string DeleteById(Guid id)
    {
        classRoomRepository.DeleteById(id);

        return "Silme işlemi başarıyla tamamlandı";
    }

    public List<ClassRoom> GetAll()
    {
        var classRooms = classRoomRepository.GetAll()
            .OrderBy(p => p.Name)
            .ThenBy(p => p.Name)
            .ToList();
        return classRooms;
    }

    public string Update(UpdateClassRoomDto request)
    {
        ClassRoom? classRoom = classRoomRepository.GetClassRoomById(request.Id);
        if (classRoom is null)
        {
            throw new ArgumentException("Sınıf bulunamadı!");
        }
        if (classRoom.Name != request.Name)
        {
            var isNameExists = classRoomRepository.Any(p => p.Name == request.Name);
            if (isNameExists)
            {
                throw new ArgumentException("Bu sınf daha önce kaydedilmiş!");
            }
        }
        mapper.Map(request, classRoom);
        classRoom.UpdatedDate = DateTime.UtcNow;
        classRoom.UpdatedBy = "Admin";
        classRoomRepository.Update(classRoom);

        return "Update işlemi başarıyla tamamlandı";
    }
}
