using DaprRegisterUser.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DaprRegisterUser.API.Controllers;

[ApiController]
[Route("api/user")]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;
	public UserController(IUserService userService)
	{
		_userService = userService;
	}


    [HttpGet("{user}")]
    public async Task<ActionResult<Domain.User>> Get(string userPartialName)
    {
        Domain.User user = await _userService.GetUserAsync(userPartialName);

        return Ok(user);
    }
}
