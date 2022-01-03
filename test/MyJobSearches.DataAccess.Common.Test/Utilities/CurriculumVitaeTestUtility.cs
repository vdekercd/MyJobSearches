namespace MyJobSearches.Common.Test.Utilities;

public class CurriculumVitaeTestUtility
{
    public static CurriculumVitae GetCurriculumVitae()
    {
        return new CurriculumVitae(
            id: 0,
            name: "MyCurriculumVitae.pdf");
    }
}

