namespace MyJobSearches.Domain.Adapters;

public class CurriculumVitaeAdapter
{
    public CurriculumVitae AdaptToCurriculumVitae(CurriculumVitaeEntity curriculumVitaeEntity)
    {
        if (curriculumVitaeEntity == null) return null!;

        return new CurriculumVitae(
            id: curriculumVitaeEntity.Id,
            name: curriculumVitaeEntity.Filename);
    }

    public CurriculumVitaeEntity AdaptToCurriculumVitaeEntity(CurriculumVitae curriculumVitae)
    {
        if (curriculumVitae == null) return null!;

        return new CurriculumVitaeEntity()
        {
            Id = curriculumVitae.Id,
            Filename = curriculumVitae.Filename
        };
    }
}
