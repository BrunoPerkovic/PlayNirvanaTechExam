using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PlayNirvanaTechExam.Dtos.Auth;
using PlayNirvanaTechExam.Entities;
using PlayNirvanaTechExam.Interfaces.Services;

namespace PlayNirvanaTechExam.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _appSettings;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private User? _user;

    public AuthService(
        UserManager<User> userManager,
        IConfiguration appSettings,
        IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _appSettings = appSettings;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IdentityResult> RegisterUser(RegisterUserDto userForRegistration)
    {
        userForRegistration.Roles = new List<string> { "User" };

        var user = new User()
        {
            UserName = userForRegistration.Username,
            PasswordHash = userForRegistration.Password,
            EmailConfirmed = true
        };
        var passwordValidationResult = await _userManager.PasswordValidators.First()
            .ValidateAsync(_userManager, user, userForRegistration.Password);

        if (!passwordValidationResult.Succeeded)
        {
            var errors = string.Join(", ", passwordValidationResult.Errors.Select(e => e.Description));
            throw new Exception($"Password is not valid. {errors}");
        }

        var result = await _userManager.CreateAsync(user, userForRegistration.Password);

        if (result.Succeeded)
            await _userManager.AddToRolesAsync(user, userForRegistration.Roles);

        return result;
    }


    public async Task<bool> LoginUser(LoginUserDto userForAuth)
    {
        _user = await _userManager.FindByNameAsync(userForAuth.Username);

        var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));

        return result;
    }

    public async Task<TokenDto> CreateToken(bool populateExp)
    {
        if (_user == null)
        {
            throw new Exception("_user is null.");
        }

        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

        var refreshToken = GenerateRefreshToken();

        _user.RefreshToken = refreshToken;

        if (populateExp)
            _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

        await _userManager.UpdateAsync(_user);

        var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return new TokenDto(accessToken, refreshToken);
    }

    public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
    {
        var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);

        var user = await _userManager.FindByNameAsync(principal.Identity.Name);
        if (user == null || user.RefreshToken != tokenDto.RefreshToken ||
            user.RefreshTokenExpiryTime <= DateTime.Now)
            throw new Exception("Invalid token");

        _user = user;

        return await CreateToken(populateExp: false);
    }

    public string GetUserId()
    {
        var userName = GetUserName();

        var userId = _userManager.Users.FirstOrDefault(u => u.UserName == userName)
            ?.Id;

        if (string.IsNullOrEmpty(userId))
        {
            throw new Exception("User ID not found in token.");
        }

        return userId;
    }

    public async Task<bool> UserExists(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return false;
        }

        return true;
    }

    private string GetUserName()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext == null)
        {
            throw new Exception("HttpContext is null.");
        }

        var user = httpContext.User;
        if (user == null || !user.Identity.IsAuthenticated)
        {
            throw new Exception("User is not authenticated.");
        }

        return user.Identity.Name;
    }

    #region Private

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }

    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_appSettings.GetValue<string>("JwtSettings:SecretKey"))),
            ValidateLifetime = true,
            ValidIssuer = _appSettings.GetValue<string>("JwtSettings:ValidIssuer"),
            ValidAudience = _appSettings.GetValue<string>("JwtSettings:ValidAudience"),
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return principal;
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_appSettings.GetValue<string>("JwtSettings:SecretKey"));
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaims()
    {
        if (_user == null || _user.UserName == null)
        {
            throw new Exception("_user or _user.UserName is null.");
        }

        var roles = await _userManager.GetRolesAsync(_user);
        if (roles == null)
        {
            throw new Exception("Roles are null.");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, _user.UserName)
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var tokenOptions = new JwtSecurityToken(issuer: _appSettings.GetValue<string>("JwtSettings:ValidIssuer"),
            audience: _appSettings.GetValue<string>("JwtSettings:ValidAudience"),
            claims: claims,
            expires: DateTime.Now.AddMinutes(7),
            signingCredentials: signingCredentials);

        return tokenOptions;
    }
    #endregion
}