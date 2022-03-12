using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJobSearches.DataAccess.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : Int32Entity
    {
        protected readonly MyJobSearchesDbContext _dbContext;

        public RepositoryBase(MyJobSearchesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected virtual DbSet<TEntity> EntityDbSet
        {
            get;
        }

        public TEntity Add(TEntity entity)
        {
            return EntityDbSet.Add(entity).Entity;
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<TEntity> FindAsync(int id)
        {
            var entity = await EntityDbSet.FindAsync(id);
            await LoadChildren(entity!);
            return entity!;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        protected virtual Task LoadChildren(TEntity entity)
        {
            return Task.CompletedTask;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await EntityDbSet.ToListAsync();
        }
    }
}
