namespace MyJobSearches.DataAccess.Entities;

[Table("CurriculumVitaes")]
public class CurriculumVitaeEntity : Int32Entity
{
    public CurriculumVitaeEntity() : base()
    {
        Filename = string.Empty;
    }

    public string Filename { get; set; }
}

