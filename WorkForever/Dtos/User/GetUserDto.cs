using WorkForever.Dtos.Factory;
using WorkForever.Models.Enums;

namespace WorkForever.Dtos.User;

public class GetUserDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public double WorkExperience { get; set; }
    public UserRole Role { get; set; }
    public double Money { get; set; }
}