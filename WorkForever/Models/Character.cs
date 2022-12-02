using WorkForever.Models.Base;

namespace WorkForever.Models;

public class Character : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public double WorkExperience { get; set; }
    
}