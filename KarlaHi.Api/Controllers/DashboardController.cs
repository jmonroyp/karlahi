using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using KarlaHi.Api.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace KarlaHi.Api.Controllers
{
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        private readonly IConfiguration _configuration;

        //requires using Microsoft.Extensions.Configuration  
        public DashboardController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<ExampleParent>> Get()
        {
            var res = await Task.Factory.StartNew<ExampleParent>(() =>
            {
                var dashboardSettings = new ExampleParent();
                _configuration.Bind("ExampleParent", dashboardSettings);
                return dashboardSettings;
            });

            //requires using Newtonsoft.Json  
            return Ok(res);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("gettoken")]
        public IActionResult GetToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(1500),
              signingCredentials: credentials);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}