using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Interfaces;
using NTierArchitecture.Entities.DTOs;

namespace NTierArchitecture.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ClassRoomsController(IClassRoomService classRoomService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var result = classRoomService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create(CreateClassRoomDto request)
    {
        var result = classRoomService.Create(request);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Update(UpdateClassRoomDto request)
    {
        var result = classRoomService.Update(request);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Delete(Guid id)
    {
        var result = classRoomService.DeleteById(id);
        return Ok(result);
    }
}
