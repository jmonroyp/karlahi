using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Test.Core.Dtos;
using Test.Core.Services;

namespace Test.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UsersService _usersService;

        public AuthenticationController(ILogger<AuthenticationController> logger,
        UsersService usersService,
        IConfiguration config)
        {
            _configuration = config;
            _usersService = usersService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<UserDto>> Get()
        {
            return await _usersService.GetAllAsync();;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate(UserDto user)
        {
            var token = await _usersService.AuthenticateAsync(user, _configuration["JWT:Key"]);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }


}