namespace MyJobSearches.Domain.Test.Adapters.Utilities;

public class CandidacyAdapterTestUtility
{
    public static void AssertAreEquals(CandidacyEntity excepted, Candidacy actual)
    {
        actual.Id.Should().Be(excepted.Id);
        actual.UserId.Should().Be(excepted.UserId);
        actual.CompanyEmail.Should().Be(excepted.EmailTo);
        actual.Filename.Should().Be(excepted.Filename);
        actual.CandidacyDate.Should().Be(DateOnly.FromDateTime(excepted.CandidacyDate));

        AssertCompany(excepted, actual);
        AssertCurriculumVitae(excepted, actual);
    }

    private static void AssertCompany(CandidacyEntity excepted, Candidacy actual)
    {
        actual.Company?.Id.Should().Be(excepted.CompanyEntity?.Id);
        actual.Company?.Name.Should().Be(excepted.CompanyEntity?.Name);
    }

    private static void AssertCurriculumVitae(CandidacyEntity excepted, Candidacy actual)
    {
        actual.CurriculumVitae?.Id.Should().Be(excepted.CurriculumVitaeEntity?.Id);
        actual.CurriculumVitae?.Filename.Should().Be(excepted.CurriculumVitaeEntity?.Filename);
    }
}
