namespace MyJobSearches.DataAccess.IntegrationTest.Utilities;

public class CurriculumVitaeEntityTestUtility
{
    public static CurriculumVitaeEntity GetANewCv()
    {
        return new CurriculumVitaeEntity()
        {
            Id = 0,
            Filename = "cv.pdf"
        };
    }

    public static void AssertAreEquals(CurriculumVitaeEntity curriculumVitaeEntity, CurriculumVitaeEntity curriculumVitae)
    {
        curriculumVitae?.Id.Should().Be(curriculumVitaeEntity?.Id);
        curriculumVitae?.Filename.Should().Be(curriculumVitaeEntity?.Filename);
    }
}

