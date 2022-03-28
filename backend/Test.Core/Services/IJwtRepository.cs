using System.Threading.Tasks;
using Test.Core.Dtos;

namespace Test.Core.Services
{
    public interface IJwtRepository
    {
        Task<AuthToken> AuthenticateAsync(UserDto user, string jwtKey);
    }
}