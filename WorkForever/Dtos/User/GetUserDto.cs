using WorkForever.Dtos.Factory;

namespace WorkForever.Dtos.User;

public class GetUserDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public double WorkExperience { get; set; }
}