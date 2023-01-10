using WorkForever.Models.Enums;

namespace WorkForever.Dtos.Factory;

public class GetFactoryDto
{
    public int Id;
    public FactoryType FactoryType { get; set; }
    public int CharacterId { get; set; }
    public int FactoryLevel { get; set; }
}