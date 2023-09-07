using Microsoft.AspNetCore.Mvc;
using Opuspac.Api.Models.Request;
using Opuspac.Api.Models.Response;
using Opuspac.Core.Services;

namespace Opuspac.Api.Controllers;

[ApiController]
[Route("/auth")]
public class AuthController : Controller
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("/sign-in")]
    public async Task<IActionResult> PostSignIn([FromBody] SignInRequestModel model)
    {
        try
        {
            var token = await _userService.GenerateSignInTokenAsync(model.Email, model.Password);
            return Ok(token);
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
}