using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using estudo_dotnet.ViewModels;
using estudo_dotnet.Interfaces.Entities;

namespace estudo_dotnet.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public sealed class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel login)
        {
            if (await _userService.Login(login.Login, login.Password))
            {
                object result = new
                {
                    token = await _userService.GenerateToken(login.Login, 120),
                    errors = new List<string>(),
                };
                
                var response = new ObjectResult(result);
                response.StatusCode = 200;
                return response;
            }
            else
            {
                object result = new
                {
                    token = "",
                    errors = "Email ou senha incorretos.",
                };
                
                var response = new ObjectResult(result);
                response.StatusCode = 400;
                return response;
            }
        }
    }
}