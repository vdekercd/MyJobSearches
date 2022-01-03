namespace MyJobSearches.Domain.Models;

public class Company
{
    public Company(int id, string name)
    {
        Id = id;
        Name = name;
    }

    [Required]
    public int Id { get; init; }
    [Required]
    public string Name { get; init; }
}

