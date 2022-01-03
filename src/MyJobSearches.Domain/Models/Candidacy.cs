namespace MyJobSearches.Domain.Models;

public class Candidacy
{
    public Candidacy(int id, Guid userId, CurriculumVitae curriculumVitae, Company company, string companyEmail, string filename, DateOnly candidacyDate)
    {
        Id = id;
        UserId = userId;
        CurriculumVitae = curriculumVitae;
        Filename = filename;
        Company = company;
        CompanyEmail = companyEmail;
        CandidacyDate = candidacyDate;
    }

    [Required]
    public int Id { get; set; }
    [Required]
    public Guid UserId { get; init; }
    [Required]
    public string Filename { get; init; }
    [Required]
    public Company Company { get; init; }
    [Required]
    [EmailAddress]
    public string CompanyEmail { get; init; }
    [Required]
    public CurriculumVitae CurriculumVitae { get; init; }
    [Required]
    [TodayOrBeforeDateOnlyValidator]
    public DateOnly CandidacyDate { get; init; }
}

