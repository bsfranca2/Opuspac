using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Opuspac.Api.Models.Request;
using Opuspac.Api.Models.Response;
using Opuspac.Core.Repositories;
using Opuspac.Core.Services;
using System.Security.Claims;

namespace Opuspac.Api.Controllers;

[ApiController]
public class AuthController : Controller
{
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;

    public AuthController(IUserService userService, IUserRepository userRepository)
    {
        _userService = userService;
        _userRepository = userRepository;
    }

    [HttpPost("/sign-in")]
    public async Task<IActionResult> PostSignIn([FromBody] SignInRequestModel model)
    {
        try
        {
            var token = await _userService.GenerateSignInTokenAsync(model.Email, model.Password);
            return Ok(new { token });
        } catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("/sign-up")]
    public async Task<IActionResult> PostSignUp([FromBody] SignUpRequestModel model)
    {
        try
        {
            var user = model.ToUser();
            await _userService.RegisterUserAsync(user);
            return Created($"/users/{user.Id}", new UserResponseModel(user));
        } catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("/me")]
    [Authorize]
    public async Task<IActionResult> Get()
    {
        var userIdentity = HttpContext.User.Identity as ClaimsIdentity;
        var claim = userIdentity?.FindFirst("userId");
        if (claim != null)
        {
            var user = await _userRepository.GetByIdAsync(Guid.Parse(claim.Value));
            return Ok(new UserResponseModel(user));
        }
        return NotFound();
    }
}