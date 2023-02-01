using WorkForever.Dtos.Factory;
using WorkForever.Dtos.Item;
using WorkForever.Models.Enums;

namespace WorkForever.Dtos.User;

public class GetUserWithEverythingDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public double WorkExperience { get; set; }
    public UserRole Role { get; set; }
    public double Money { get; set; }
    public List<GetFactoryDto> Factories { get; set; } = new List<GetFactoryDto>();
    public List<GetItemInventoryDto> ItemInventories { get; set; } = new List<GetItemInventoryDto>();
}