namespace MyJobSearches.Common.Test.Utilities;

public class CandidacyEntityTestUtility
{
    public static CandidacyEntity GetDamienVdk()
    {
        return new CandidacyEntity()
        {
            Id = 0,
            UserId = Guid.NewGuid(),
            Filename = "copyEmail.png",
            EmailTo = "damienvdk@gmail.com",
            CandidacyDate = new DateTime(2021, 11, 18),
            CompanyEntity = new CompanyEntity()
            {
                Id = 0,
                Name = "Oniryx"
            },
            CurriculumVitaeEntity = new CurriculumVitaeEntity()
            {
                Id = 0,
                Filename = "cv.png"
            }
        };
    }

    public static void AssertAreEquals(CandidacyEntity candidacyEntity1, CandidacyEntity candidacyEntity2)
    {
        candidacyEntity2.CandidacyDate.Should().Be(candidacyEntity1.CandidacyDate);
        candidacyEntity2.Filename.Should().Be(candidacyEntity1.Filename);
        candidacyEntity2.EmailTo.Should().Be(candidacyEntity1.EmailTo);
        candidacyEntity2.UserId.Should().Be(candidacyEntity1.UserId);
        AssertCompany(candidacyEntity1, candidacyEntity2);
        AssertCurriculumVitae(candidacyEntity1, candidacyEntity2);
    }

    private static void AssertCompany(CandidacyEntity candidacyEntity1, CandidacyEntity candidacyEntity2)
    {
        candidacyEntity2.CompanyEntity.Id.Should().Be(candidacyEntity1.CompanyEntity.Id);
        candidacyEntity2.CompanyEntity.Name.Should().Be(candidacyEntity1.CompanyEntity.Name);
    }

    private static void AssertCurriculumVitae(CandidacyEntity candidacyEntity1, CandidacyEntity candidacyEntity2)
    {
        candidacyEntity2.CurriculumVitaeEntity.Id.Should().Be(candidacyEntity1.CurriculumVitaeEntity.Id);
        candidacyEntity2.CurriculumVitaeEntity.Filename.Should().Be(candidacyEntity1.CurriculumVitaeEntity.Filename);
    }
}
