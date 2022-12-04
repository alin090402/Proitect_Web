namespace WorkForever.Dtos.Character;

public class UpdateCharacterDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public double WorkExperience { get; set; }

}