namespace MyJobSearches.DataAccess.IntegrationTest.Utilities;

public class MyJobSearchesDbContextUtility
{
    private static bool _needToDeleteDatabase = false;

    public static async Task<IRepository<TEntity>> GetRepository<TEntity, TRespository>(IRepository<TEntity> instance)
    where TEntity : Int32Entity
    where TRespository : RepositoryBase<TEntity>, IRepository<TEntity>
    {
        if (instance == null)
        {
            instance = (TRespository)Activator.CreateInstance(typeof(TRespository), await GetMyJobSearchesDbContext());
            if (instance == null) throw new ArgumentNullException(nameof(instance));
        }
        return instance;
    }

    public static async Task<MyJobSearchesDbContext> GetMyJobSearchesDbContext()
    {
        var context = new MyJobSearchesDeignTimeDbContext().Create();
        await DeleteDatabaseIfFirstCall(context);
        await context.Database.EnsureCreatedAsync();
        return context;
    }

    private static async Task DeleteDatabaseIfFirstCall(MyJobSearchesDbContext context)
    {
        if (!_needToDeleteDatabase) await context.Database.EnsureDeletedAsync();
        _needToDeleteDatabase = true;
    }
}

