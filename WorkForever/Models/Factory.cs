using Microsoft.AspNetCore.SignalR;
using WorkForever.Models.Base;
using WorkForever.Models.Enums;

namespace WorkForever.Models;

public class Factory: BaseEntity
{
    public FactoryType FactoryType { get; set; }
    public Character Character { get; set; }
    public int CharacterId { get; set; }
    public int FactoryLevel { get; set; }
}