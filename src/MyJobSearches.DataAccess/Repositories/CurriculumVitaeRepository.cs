namespace MyJobSearches.DataAccess.Repositories;

public class CurriculumVitaeRepository : RepositoryBase<CurriculumVitaeEntity>
{
    protected override DbSet<CurriculumVitaeEntity> EntityDbSet { get; }

    public CurriculumVitaeRepository(MyJobSearchesDbContext context) : base(context)
    {
        EntityDbSet = _dbContext.CurriculumVitaeEntities!;
    }
}

