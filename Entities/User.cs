using Microsoft.AspNetCore.Identity;

namespace PlayNirvanaTechExam.Entities;

public class User : IdentityUser
{
    public string? RefreshToken { get; set; }
    private DateTime _refreshTokenExpiryTime;

    public DateTime RefreshTokenExpiryTime
    {
        get => _refreshTokenExpiryTime;
        set => _refreshTokenExpiryTime = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
    