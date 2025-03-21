using Microsoft.AspNetCore.Mvc;
using StrataManagementAPI.Models;
using StrataManagementAPI.Services;

namespace StrataManagementAPI.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestModel request)
    {
        var result = await authService.Login(request.Username, request.Password);

        if (!result.Success)
        {
            return Unauthorized(new { errors = result.Errors });
        }

        return Ok(new { token = result.Token, userRole = result.UserRole });
    }
}
