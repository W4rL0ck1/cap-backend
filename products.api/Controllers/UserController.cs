using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> CreateHash([FromBody] AuthParams jsonBody)
    {
            var newHash = _securityService.CreateHMACSHA512Hash(jsonBody.Password);
            return Ok(new { Hash = newHash });
    }

    [HttpPost("AuthenticateUser")]
    public async Task<IActionResult> AuthenticateUser([FromBody] AuthParams jsonBody)
    {
            var result = await _userService.Authenticate(jsonBody);

            if(result == null) return BadRequest("Usuário ou senha Incorretos!");

            return Ok(new { data = result.User, token = result.Token });
    }
}
