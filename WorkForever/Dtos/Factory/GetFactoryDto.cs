using WorkForever.Models.Enums;

namespace WorkForever.Dtos.Factory;

public class GetFactoryDto
{
    public int Id;
    public FactoryType Type { get; set; }
    public int UserId { get; set; }
    public int Level { get; set; }
}