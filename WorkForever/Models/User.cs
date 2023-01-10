using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WorkForever.Models.Base;
using WorkForever.Models.Enums;

namespace WorkForever.Models;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(Username), IsUnique = true)]
public class User : BaseEntity
{
    public string Username { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string Email { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.User;
    public double WorkExperience { get; set; }
    public List<Factory> Factories { get; set; } 
}