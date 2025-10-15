using Microsoft.AspNetCore.Mvc;
using RhSensoERP.Api.Models;
using RhSensoERP.Api.Services;

namespace RhSensoERP.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public ActionResult<LoginResponse> Login(LoginRequest request)
    {
        var result = _authService.Login(request);
        return result is null ? Unauthorized() : Ok(result);
    }
}
