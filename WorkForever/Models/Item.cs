using WorkForever.Models.Base;

namespace WorkForever.Models;

public class Item: BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}