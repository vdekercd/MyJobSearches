namespace MyJobSearches.DataAccess;

public class MyJobSearchesDbContext : DbContext
{
    public MyJobSearchesDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<CandidacyEntity>? CandidacyEntities { get; set; }
    public DbSet<CurriculumVitaeEntity>? CurriculumVitaeEntities { get; set; }
}

