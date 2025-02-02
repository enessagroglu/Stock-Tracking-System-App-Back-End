using Microsoft.AspNetCore.Mvc;
using StockTrackingSystemApp_BackEnd.Application.DTOs;
using StockTrackingSystemApp_BackEnd.Application.Interfaces;
using System.Threading.Tasks;

namespace StockTrackingSystemApp_BackEnd.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationDto registrationDto)
        {
            var result = await _userService.RegisterUserAsync(registrationDto);
            return Ok(result);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            var result = await _userService.AuthenticateUserAsync(loginDto);
            return Ok(result);
        }
    }
}