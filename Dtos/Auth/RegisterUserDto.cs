namespace PlayNirvanaTechExam.Dtos.Auth;

public record RegisterUserDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<string> Roles { get; set; }
};