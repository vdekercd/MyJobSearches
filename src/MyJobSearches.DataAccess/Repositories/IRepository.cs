namespace MyJobSearches.DataAccess.Repositories;

public interface IRepository<TEntity> where TEntity : Int32Entity
{
    TEntity Add(TEntity entity);
    Task<TEntity> FindAsync(int entityId);
    Task SaveChangesAsync();
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<List<TEntity>> GetAllAsync();
}
