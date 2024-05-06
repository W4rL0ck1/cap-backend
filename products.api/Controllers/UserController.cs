using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using products.application.DTO;
using Products.Application;
using Products.Application.DTO;
using Products.Application.Interfaces;

namespace products.api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private ISecurityService _securityService;

    private IUserService _userService;

    public UserController(ILogger<UserController> logger,
                         ISecurityService securityService, 
                         IUserService userService)
    {
        _logger = logger;
        _securityService = securityService;
        _userService = userService;
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
            var result = await _userService.Authenticate(jsonBody);

            if(!result.Success) return BadRequest(result.Message);

            return Ok(new { data = result.Result, token = result.Result.Token });
    }

    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser([FromBody] NewUserDTO jsonBody)
    {
            var result = await _userService.CreateUser(jsonBody);

            if(!result.Success) return BadRequest(result.Message);

            return Ok(result);
    }
}
