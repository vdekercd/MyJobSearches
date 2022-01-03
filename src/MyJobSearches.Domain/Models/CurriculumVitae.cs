namespace MyJobSearches.Domain.Models;

public class CurriculumVitae
{
    public CurriculumVitae(int id, string name)
    {
        Id = id;
        Filename = name;
    }

    [Required]
    public int Id { get; init; }
    [Required]
    public string Filename { get; init; }
}