using EasyMenu.Core.Dtos;
using EasyMenu.Portal.Models;
using EasyMenu.Portal.Models.Maps;
using EasyMenu.Portal.Services.Interfaces;
using EasyMenu.Portal.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyMenu.Portal.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private const string IncorrectLoginResponseParam = "IncorrectLoginResponse";
    private const string DisabledLoginResponseParam = "DisabledLoginResponse";
    private const string UserLockResponseParam = "UserLockLoginResponse";

    private readonly IAuthService _authService;
    private readonly IUserService _userService;

    public AuthController(IAuthService authService,
        IUserService userService)
    {
        _userService = userService;
        _authService = authService;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] Credentials credentials)
    {
        var loginValidator = new CredentialsValidator();
        var loginValidatorResult = await loginValidator.ValidateAsync(credentials);

        if (!loginValidatorResult.IsValid)
        {
            var errors = loginValidatorResult.Errors.Select(failure => failure.ErrorMessage)
                .Aggregate(string.Empty, (s, s1) => string.IsNullOrWhiteSpace(s) ? $"{s1}" : $"{s}|{s1}");
            var response = BadRequest(new ErrorResponse(errors));
            return response;
        }

        var loginResult = await _authService.Login(credentials);
        if (loginResult.IsDisabled)
        {
            return Unauthorized(new ErrorResponse(DisabledLoginResponseParam));
        }

        if (loginResult.IsLockedOut)
        {
            return StatusCode(StatusCodes.Status423Locked,
                new ErrorResponse(UserLockResponseParam));
        }

        if (!loginResult.Succeeded)
        {
            var response = Unauthorized(new ErrorResponse(IncorrectLoginResponseParam));
            return response;
        }

        var user = loginResult.Data;
        var session = await _userService.NewSession(user);
        if (!session) throw new Exception();
        
        var authUser = user.Map();

        var token = _authService.BuildToken(authUser, loginResult.IsNotAllowed);
        var authResponse = new AuthResponse
        {
            User = authUser,
            Token = token.ToString()
        };

        return loginResult.IsNotAllowed
            ? StatusCode(StatusCodes.Status419AuthenticationTimeout, authResponse)
            : Ok(authResponse);
    }
}