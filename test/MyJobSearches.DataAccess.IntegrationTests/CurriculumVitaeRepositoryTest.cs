

namespace MyJobSearches.DataAccess.IntegrationTest;

public class CurriculumVitaeRepositoryTest
{
    private static IRepository<CurriculumVitaeEntity>? _curriculumVitaeRepository;


    [Fact]
    public async Task EntityFramework_SaveCurriculumVitae()
    {
        // Create
        var curriculumVitaeEntity1 = await CreateAsync();
        curriculumVitaeEntity1.Id.Should().BeGreaterThan(0);

        // Assert from database
        var curriculumVitaeEntity2 = await ReloadRepositoryAndGetAsync(curriculumVitaeEntity1.Id);
        CurriculumVitaeEntityTestUtility.AssertAreEquals(curriculumVitaeEntity1, curriculumVitaeEntity2);
    }

    [Fact]
    public async Task EntityFramework_UpdateCurriculumVitae()
    {
        // Create
        var curriculumVitaeEntity1 = await CreateAsync();

        // Update
        var curriculumVitaeEntity2 = await ReloadRepositoryAndGetAsync(curriculumVitaeEntity1.Id);
        curriculumVitaeEntity2.Filename = "FakeCV.pdf";
        _curriculumVitaeRepository!.Update(curriculumVitaeEntity2);
        await _curriculumVitaeRepository.SaveChangesAsync();

        // Assert from database
        var curriculumVitaeEntity3 = await ReloadRepositoryAndGetAsync(curriculumVitaeEntity1.Id);
        curriculumVitaeEntity3.Filename.Should().Be("FakeCV.pdf");
        curriculumVitaeEntity3.Id.Should().Be(curriculumVitaeEntity1.Id);
    }

    [Fact]
    public async Task EntityFramework_DeleteCurriculumVitae()
    {
        // Create
        var curriculumVitaeEntity1 = await CreateAsync();

        // Update
        var curriculumVitaeEntity2 = await ReloadRepositoryAndGetAsync(curriculumVitaeEntity1.Id);
        _curriculumVitaeRepository!.Delete(curriculumVitaeEntity2);
        await _curriculumVitaeRepository.SaveChangesAsync();

        // Assert from database
        var curriculumVitaeEntity3 = await ReloadRepositoryAndGetAsync(curriculumVitaeEntity1.Id);
        curriculumVitaeEntity3.Should().BeNull();
    }

    private async Task<CurriculumVitaeEntity> CreateAsync()
    {
        var curriculumVitaeEntity = CurriculumVitaeEntityTestUtility.GetANewCv();

        await UpdateCurriculumVitaeRepositoryInstanceAsync();
        _curriculumVitaeRepository!.Add(curriculumVitaeEntity);
        await _curriculumVitaeRepository.SaveChangesAsync();

        return curriculumVitaeEntity;
    }

    private async Task<CurriculumVitaeEntity> ReloadRepositoryAndGetAsync(int id)
    {
        _curriculumVitaeRepository = null;
        await UpdateCurriculumVitaeRepositoryInstanceAsync();
        return await _curriculumVitaeRepository!.FindAsync(id);
    }

    private async Task UpdateCurriculumVitaeRepositoryInstanceAsync()
    {
        _curriculumVitaeRepository =
            await MyJobSearchesDbContextUtility.GetRepository<CurriculumVitaeEntity, CurriculumVitaeRepository>(_curriculumVitaeRepository!);
    }
}
