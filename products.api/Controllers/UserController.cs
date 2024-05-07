using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using products.application.DTO;
using products.application.Validators.Erros;
using Products.Application;
using Products.Application.DTO;
using Products.Application.Interfaces;

namespace products.api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly ISecurityService _securityService;
    private readonly IUserService _userService;

    private readonly IValidator<AuthParamsDTO> _authParamsDtoValidator;
    private readonly IValidator<NewUserDTO> _newUserDTOValidator;

    public UserController(ILogger<UserController> logger,
                         ISecurityService securityService, 
                         IUserService userService,
                         IValidator<AuthParamsDTO> authParamsDtoValidator,
                         IValidator<NewUserDTO> newUserDTOValidator)
    {
        _logger = logger;
        _securityService = securityService;
        _userService = userService;
        _authParamsDtoValidator = authParamsDtoValidator;
        _newUserDTOValidator = newUserDTOValidator;
    }

    [HttpPost("CreateHash")]
    public async Task<IActionResult> CreateHash([FromBody] AuthParamsDTO jsonBody)
    {
            var newHash = _securityService.CreateHMACSHA512Hash(jsonBody.Password);
            return Ok(new { Hash = newHash });
    }

    [HttpPost("AuthenticateUser")]
    public async Task<IActionResult> AuthenticateUser([FromBody] AuthParamsDTO jsonBody)
    {
        var validationResult = _authParamsDtoValidator.Validate(jsonBody);
        if (!validationResult.IsValid) return BadRequest(validationResult.Errors.ToCustomValidationFailure());

        var result = await _userService.Authenticate(jsonBody);

        if(!result.Success) return BadRequest(result.Message);

        return Ok(new { data = result.Result, token = result.Result.Token });
    }

    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser([FromBody] NewUserDTO jsonBody)
    {
        var validationResult = _newUserDTOValidator.Validate(jsonBody);
        if (!validationResult.IsValid) return BadRequest(validationResult.Errors.ToCustomValidationFailure());

        var result = await _userService.CreateUser(jsonBody);

        if(!result.Success) return BadRequest(result.Message);

        return Ok(result);
    }
}
