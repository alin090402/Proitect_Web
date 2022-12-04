namespace WorkForever.Models.Base;

public interface IBaseEntity
{
    int Id { get; set; }
    DateTime? CreatedDate { get; set; }
    DateTime? ModifiedDate { get; set; }
}