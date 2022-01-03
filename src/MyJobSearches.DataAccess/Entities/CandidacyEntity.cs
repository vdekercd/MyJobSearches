namespace MyJobSearches.DataAccess.Entities;

[Table("Candidacies")]
public class CandidacyEntity : Int32Entity
{
    public CandidacyEntity() : base() 
    {
        EmailTo = string.Empty;
        Filename = string.Empty;
        CompanyEntity = null!;
        CurriculumVitaeEntity = null!;
        CandidacyDate = DateTime.MinValue;
    }

    public Guid UserId { get; set; }
    public string EmailTo { get; set; }
    public string Filename { get; set; }
    public CompanyEntity CompanyEntity { get; set; }
    public CurriculumVitaeEntity CurriculumVitaeEntity { get; set; }
    public DateTime CandidacyDate { get; set; }
}

