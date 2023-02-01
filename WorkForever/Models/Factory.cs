using WorkForever.Models.Base;
using WorkForever.Models.Enums;

namespace WorkForever.Models;

public class Factory: BaseEntity
{
    public FactoryType Type { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
    public int Level { get; set; }
    public Item ItemCreated { get; set; }
    public int ItemCreatedId { get; set; }
    public double Salary { get; set; }
}