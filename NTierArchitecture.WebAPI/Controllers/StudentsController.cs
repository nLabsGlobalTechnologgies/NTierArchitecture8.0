using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Interfaces;
using NTierArchitecture.Entities.DTOs;

namespace NTierArchitecture.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class StudentsController(IStudentService studentService) : ControllerBase
{
    [HttpPost]
    public IActionResult Create(CreateStudentDto request)
    {
        string message = studentService.Create(request);
        return Ok(new { Message = message });
    }

    [HttpPost]
    public IActionResult Update(UpdateStudentDto request)
    {
        string message = studentService.Update(request);
        return Ok(new { Message = message });
    }

    [HttpGet("{id}")]
    public IActionResult DeleteById(Guid id)
    {
        string message = studentService.DeleteById(id);
        return Ok(new { Message = message });
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = studentService.GetAll();
        return Ok(response);
    }
}
