using Microsoft.AspNetCore.Mvc;
using PlayNirvanaTechExam.Dtos.Auth;
using PlayNirvanaTechExam.Interfaces.Services;

namespace PlayNirvanaTechExam.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public AuthController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserDto loginUserDto)
    {
        if (!await _serviceManager.AuthService.LoginUser(loginUserDto))
        {
            return Unauthorized();
        }

        var result = await _serviceManager.AuthService.CreateToken(true);
        await _serviceManager.NotificationService.NotifySearchPerformed(
            nameof(AuthController).Replace("Controller", ""),
            nameof(LoginUser),
            Request.QueryString.ToString(),
            Request.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown",
            result
        );
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto registerUserDto)
    {
        var result = await _serviceManager.AuthService.RegisterUser(registerUserDto);

        if (result.Succeeded) return StatusCode(201);
        
        foreach (var error in result.Errors)
        {
            ModelState.TryAddModelError(error.Code, error.Description);
        }

        await _serviceManager.NotificationService.NotifySearchPerformed(
            nameof(AuthController).Replace("Controller", ""),
            nameof(LoginUser),
            Request.QueryString.ToString(),
            Request.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown",
            result
        );
        
        return StatusCode(400, ModelState);

    }
}