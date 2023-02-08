using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkForever.Models.Base;

namespace WorkForever.Models;

public class WorkRecord : BaseEntity
{
    
    public User? User { get; set; }
    public int UserId { get; set; }
    public Factory? Factory { get; set; }
    public int FactoryId { get; set; }
    public double MoneyEarned { get; set; }
    public int ItemsEarned { get; set; }
    public DateTime WorkedAt { get; set; }
}