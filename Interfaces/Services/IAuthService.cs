using Microsoft.AspNetCore.Identity;
using PlayNirvanaTechExam.Dtos.Auth;

namespace PlayNirvanaTechExam.Interfaces.Services;

public interface IAuthService
{
    Task<IdentityResult> RegisterUser(RegisterUserDto userForRegistration);
    Task<bool> LoginUser(LoginUserDto userForAuth);
    Task<TokenDto> CreateToken(bool populateExp);
    Task<TokenDto> RefreshToken(TokenDto tokenDto);
    string GetUserId();
    Task<bool> UserExists(string email);
}