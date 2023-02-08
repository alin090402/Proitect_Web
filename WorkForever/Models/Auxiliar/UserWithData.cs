using WorkForever.Models.Enums;

namespace WorkForever.Models.Composed;

public class UserWithData
{
    public int Id { get; set; }
    public string Username { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string Email { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.User;
    public double WorkExperience { get; set; }
    public List<Factory> Factories { get; set; }
    public DateTime? LastWorked { get; set; }
}