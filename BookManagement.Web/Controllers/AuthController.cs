using BookManagement.Domain.Entity;
using BookManagement.Domain.Enum;
using BookManagement.Infrastructure.Identity;
using BookManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenProvader _tokenProvider;
        public AuthController(UserManager<User> userManager, TokenProvader tokenProvader)
        {
            _tokenProvider = tokenProvader;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = new User
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await _userManager.AddToRoleAsync(user, ApplicationRole.User.ToString());

            return Ok(new { Message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                return Unauthorized();
            }

            var isValidPassword = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!isValidPassword)
            {
                return Unauthorized();
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = _tokenProvider.GenerateJwtToken(user, roles);

            return Ok(new { Token = token });
        }
    }
}
