namespace WorkForever.Models;

public class UserItem
{
    public User User { get; set; }
    public int UserId { get; set; }
    public Item Item { get; set; }
    public int ItemId { get; set; }
    public int Quantity { get; set; }
}