using WorkForever.Models.Enums;

namespace WorkForever.Dtos.Factory;

public class GetFactoryDto
{
    public int Id { get; set; }
    public FactoryType Type { get; set; }
    public int UserId { get; set; }
    public int Level { get; set; }
    public int ItemCreatedId { get; set; }
    public double Salary { get; set; }
}