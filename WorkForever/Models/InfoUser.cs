using WorkForever.Models.Base;

namespace WorkForever.Models;

public class InfoUser:BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public int UserId { get; set; }
    public User User { get; set; }
}