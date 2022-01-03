using MyJobSearches.DataAccess.IntegrationTest.Utilities;
using MyJobSearches.DataAccess.Repositories;

namespace MyJobSearches.DataAccess.IntegrationTest;

public class CandidacyRepositoryTest
{
    private static IRepository<CandidacyEntity>? _candidacyRepository;

    [Fact]
    public async Task EntityFramework_SaveCandidacy()
    {
        // Create
        var candidacyEntity1 = await CreateAsync();
        candidacyEntity1.Id.Should().BeGreaterThan(0);

        // Assert from database
        var candidacyEntity2 = await ReloadRepositoryAndGetAsync(candidacyEntity1.Id);
        CandidacyEntityTestUtility.AssertAreEquals(candidacyEntity1, candidacyEntity2);
    }

    [Fact]
    public async Task EntityFramework_UpdateCandidacy()
    {
        // Create
        var candidacyEntity1 = await CreateAsync();

        // Update
        var candidacyEntity2 = await ReloadRepositoryAndGetAsync(candidacyEntity1.Id);
        candidacyEntity2.EmailTo = "FakeMail@gmail.com";
        _candidacyRepository!.Update(candidacyEntity2);
        await _candidacyRepository.SaveChangesAsync();

        // Assert from database
        var candidacyEntity3 = await ReloadRepositoryAndGetAsync(candidacyEntity1.Id);
        candidacyEntity3.EmailTo.Should().Be("FakeMail@gmail.com");
        candidacyEntity3.Id.Should().Be(candidacyEntity1.Id);
    }

    [Fact]
    public async Task EntityFramework_DeleteCandidacy()
    {
        // Create
        var candidacyEntity1 = await CreateAsync();

        // Update
        var candidacyEntity2 = await ReloadRepositoryAndGetAsync(candidacyEntity1.Id);
        _candidacyRepository!.Delete(candidacyEntity2);
        await _candidacyRepository.SaveChangesAsync();

        // Assert from database
        var candidacyEntity3 = await ReloadRepositoryAndGetAsync(candidacyEntity1.Id);
        candidacyEntity3.Should().BeNull();
    }

    private async Task<CandidacyEntity> CreateAsync()
    {
        var candidacyEntity = CandidacyEntityTestUtility.GetDamienVdk();

        await UpdateCandidacyRepositoryInstance();
        _candidacyRepository!.Add(candidacyEntity);
        await _candidacyRepository.SaveChangesAsync();

        return candidacyEntity;
    }

    private async Task<CandidacyEntity> ReloadRepositoryAndGetAsync(int id)
    {
        _candidacyRepository = null;
        await UpdateCandidacyRepositoryInstance();
        return await _candidacyRepository!.FindAsync(id);
    }

    private async Task UpdateCandidacyRepositoryInstance()
    {
        _candidacyRepository = 
            await MyJobSearchesDbContextUtility.GetRepository<CandidacyEntity, CandidacyRepository>(_candidacyRepository!);
    }
}

