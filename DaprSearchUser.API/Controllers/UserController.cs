using Microsoft.AspNetCore.Mvc;
using DaprSearchUser.API.Services;
//using DaprRegisterUser.API.Services;

namespace DaprSearchUser.API.Controllers;

[ApiController]
[Route("api/user")]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    [HttpGet("{user}")]
    public async Task<ActionResult<Domain.User>> Get(string userPartialName)
    {
        Domain.User user = await _userService.GetUserAsync(userPartialName);

        return Ok(user);
    }

    [HttpPost("{user")]
    public async Task<ActionResult<Domain.User>> Post(string userPartialName, Domain.User user)
    {
        try
        {
            await _userService.AddUserAsync(userPartialName, user);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}
