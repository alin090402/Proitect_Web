using WorkForever.Models.Enums;

namespace WorkForever.Dtos.Factory;

public class AddFactoryDto
{
    public FactoryType Type { get; set; }
    public int ItemCreatedId { get; set; }
    public double Salary { get; set; }
}