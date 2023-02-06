using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Services.Users;
using Sample.Shared.Dtos;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost()]
        public IActionResult Post(LoginDto login)
        {
            return Ok(_userService.LoginAsync(login));
        }
        [HttpPost("Refresh")]
        public IActionResult Post(TokenRequest tokenRequest)
        {
            return Ok(_userService.VerifyToken(tokenRequest));
        }
    }
}
