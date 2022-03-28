using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Test.Core.Dtos;
using Test.Infraestructure.Entities;
using Test.Infraestructure.Repositories;
using Test.Infraestructure.Specifications;

namespace Test.Core.Services
{
    public class UsersService : DbService<UserDto, User>, IJwtRepository
    {
        public UsersService(IRepository<User> repo, IMapper mapper) : base(repo, mapper)
        {
        }

        public async Task<AuthToken> AuthenticateAsync(UserDto user, string jwtKey)
        {
            var usr = await GetBySpecAsync(new AuthSpecification(user.Username, user.Password));
            if (user == null)
                return null;

            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(jwtKey); //iconfiguration["JWT:Key"]
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, user.Username)
              }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthToken { Token = tokenHandler.WriteToken(token) };
        }
    }
}