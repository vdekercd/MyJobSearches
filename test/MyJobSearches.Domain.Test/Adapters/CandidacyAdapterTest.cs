namespace MyJobSearches.Domain.Test.Adapters;

public class CandidacyAdapterTest
{
    [Fact]
    public void CandidacyAdapter_AdaptCandidacyEntityToCandidacy()
    {
        var adapter = new CandidacyAdapter();
        var candidacyEntity = CandidacyEntityTestUtility.GetDamienVdk();
        var candidacy = adapter.AdaptToCandidacy(candidacyEntity);
        CandidacyAdapterTestUtility.AssertAreEquals(candidacyEntity, candidacy);
    }

    [Fact]
    public void CandidacyAdapter_AdaptToCandidacyNullReference()
    {
        var adapter = new CandidacyAdapter();
        var candidacy = adapter.AdaptToCandidacy(null!);
        candidacy.Should().BeNull();
    }

    [Fact]
    public void CandidacyAdapter_AdaptCandidacyEntityToCandidacyWithNullChildren()
    {
        var adapter = new CandidacyAdapter();
        var candidacyEntity = CandidacyEntityTestUtility.GetDamienVdk();
        candidacyEntity.CurriculumVitaeEntity = null!;
        candidacyEntity.CompanyEntity = null!;
        var candidacy = adapter.AdaptToCandidacy(candidacyEntity);
        candidacy.CurriculumVitae.Should().BeNull();
        candidacy.Company.Should().BeNull();
    }

    [Fact]
    public void CandidacyAdapter_AdaptCandidacyToCandidacyEntity()
    {
        var adapter = new CandidacyAdapter();
        var candidacy = CandidacyTestUtility.GetValidCandidacy();
        var candidacyEntity = adapter.AdaptToCandidacyEntity(candidacy);
        CandidacyAdapterTestUtility.AssertAreEquals(candidacyEntity, candidacy);
    }

    [Fact]
    public void CandidacyAdapter_AdaptCandidacyToCandidacyEntityWithNullChildren()
    {
        var adapter = new CandidacyAdapter();
        var candidacy = CandidacyTestUtility.GetWithNullChildrenCandidacy();
        var candidacyEntity = adapter.AdaptToCandidacyEntity(candidacy);
        candidacyEntity.CurriculumVitaeEntity.Should().BeNull();
        candidacyEntity.CompanyEntity.Should().BeNull();
    }


    [Fact]
    public void CandidacyAdapter_AdaptToCandidacyEntityNullReference()
    {
        var adapter = new CandidacyAdapter();
        var candidacyEntity = adapter.AdaptToCandidacyEntity(null!);
        candidacyEntity.Should().BeNull();
    }
}

