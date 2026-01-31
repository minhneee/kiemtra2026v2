using Microsoft.AspNetCore.Mvc;
using PickleballClubManagement.Dtos;

namespace PickleballClubManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest(new AuthResponse 
            { 
                Success = false, 
                Message = "Username and password are required" 
            });
        }

        return Ok(new AuthResponse 
        { 
            Success = true, 
            Message = "Registration successful" 
        });
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
        {
            return Unauthorized(new AuthResponse 
            { 
                Success = false, 
                Message = "Invalid credentials" 
            });
        }

        return Ok(new AuthResponse 
        { 
            Success = true, 
            Message = "Login successful" 
        });
    }
}
