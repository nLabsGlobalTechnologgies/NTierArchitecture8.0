using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Interfaces;
using NTierArchitecture.Entities.DTOs;

namespace NTierArchitecture.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController(IUserService userManager) : ControllerBase
{
    [HttpPost]
    public IActionResult Register(RegisterDto request)    {

        var result = userManager.Register(request);
        if (result is null)
        {
            return BadRequest("Kayıt işlemi sırasında hata oluştu!");
        }
        return Ok("Kullanıcı Kaydı başarıyla gerçekleşti");
    }

    [HttpPost]
    public IActionResult Login(LoginDto request)
    {
        var response = userManager.Login(request);
        if (response is null)
        {
            return BadRequest("Bilgiler eşleşmiyor!");
        }
        return Ok(response);
    }
}
