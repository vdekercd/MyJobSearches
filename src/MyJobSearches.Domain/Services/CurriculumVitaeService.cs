namespace MyJobSearches.Domain.Services;
public class CurriculumVitaeService
{
    private readonly CurriculumVitaeAdapter _curriculumVitaeAdapter = new CurriculumVitaeAdapter();
    private readonly IRepository<CurriculumVitaeEntity> _curriculumVitaeRepository;
    private readonly IRepository<CandidacyEntity> _candidacyRepository;

    public CurriculumVitaeService(IRepository<CurriculumVitaeEntity> curriculumVitaeRepository, IRepository<CandidacyEntity> candidacyRepository)
    {
        _curriculumVitaeRepository = curriculumVitaeRepository;
        _candidacyRepository = candidacyRepository;
    }

    public async Task<int> AddNewCurriculumVitaeAsync(CurriculumVitae curriculumVitae)
    {
        var curriculumVitaeEntity =  _curriculumVitaeAdapter.AdaptToCurriculumVitaeEntity(curriculumVitae);
        _curriculumVitaeRepository.Add(curriculumVitaeEntity);
        await _curriculumVitaeRepository.SaveChangesAsync();
        return curriculumVitaeEntity.Id;
    }

    public async Task UpdateCurricilumVitaeAsync(CurriculumVitae curriculumVitae)
    {
        var curriculumVitaeEntity = _curriculumVitaeAdapter.AdaptToCurriculumVitaeEntity(curriculumVitae);
        _curriculumVitaeRepository.Update(curriculumVitaeEntity);
        await _curriculumVitaeRepository.SaveChangesAsync();
    }

    public async Task DeleteCurriculumVitaeByIdAsync(int id)
    {
        var curriculumVitaeEntity = await GetCurriculumByIdAsync(id);
        await CheckIfCurriculumVitaedUsedInCandidaciesAsync(id);
        _curriculumVitaeRepository.Delete(curriculumVitaeEntity);
        await _curriculumVitaeRepository.SaveChangesAsync();
    }

    private async Task CheckIfCurriculumVitaedUsedInCandidaciesAsync(int id)
    {
        var candidacies = (await _candidacyRepository.GetAllAsync())
            .Where(item => item.CurriculumVitaeEntity.Id == id)
            .ToList();
        if (candidacies?.Any() ?? false)
            throw new Exception("CURRICULUM_USED_IN_CANDIDACIES");
    }

    private async Task<CurriculumVitaeEntity> GetCurriculumByIdAsync(int id)
    {
        var curriculumVitaeEntity = await _curriculumVitaeRepository.FindAsync(id);
        if (curriculumVitaeEntity == null)
            throw new Exception("CURRICULUM_ID_NOT_EXISTS");
        return curriculumVitaeEntity;
    }
}

