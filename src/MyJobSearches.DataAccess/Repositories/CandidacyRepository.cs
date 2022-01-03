namespace MyJobSearches.DataAccess.Repositories;

public class CandidacyRepository : RepositoryBase<CandidacyEntity>
{
    protected override DbSet<CandidacyEntity> EntityDbSet { get; }

    public CandidacyRepository(MyJobSearchesDbContext context) : base(context)
    {
        EntityDbSet = _dbContext.CandidacyEntities;
    }

    protected override async Task LoadChildren(CandidacyEntity candidacy)
    {
        if (candidacy != null)
        {
            await _dbContext.Entry(candidacy)
                .Reference(item => item.CurriculumVitaeEntity).LoadAsync();
            await _dbContext.Entry(candidacy)
                .Reference(item => item.CompanyEntity).LoadAsync();
        }
    }
}
