namespace MyJobSearches.DataAccess.Test.Repositories;

public class InMemoryRepository<T> : IRepository<T> where T : Int32Entity
{
    private enum ChangeType
    {
        Unchanged,
        Added,
        Changed,
        Deleted
    };

    private int _currentIdentityValue = 0;
    private Dictionary<T, ChangeType> _currentUnsavedList = new Dictionary<T, ChangeType>();

    public List<T> Items { get; set; } = new List<T>();

    public T Add(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        _currentUnsavedList.Add(entity, ChangeType.Added);
        return entity;
    }

    public void Delete(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        var itemToDelete = GetFromUsavedList(entity.Id);
        _currentUnsavedList[itemToDelete] = ChangeType.Deleted;
    }

    public Task<T> FindAsync(int id)
    {
        return Task.FromResult(GetFromUsavedList(id));
    }

    public void Update(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        var entityToUpdate = GetFromUsavedList(entity.Id);
        if (entityToUpdate != null) _currentUnsavedList.Remove(entityToUpdate);

        _currentUnsavedList.Add(entity, ChangeType.Changed);
    }

    public Task SaveChangesAsync()
    {
        Items.Clear();
        foreach(var item in _currentUnsavedList.Where(item => item.Value != ChangeType.Deleted))
        {
            if (item.Value == ChangeType.Added)
                item.Key.Id = GetNextIdValue();

            Items.Add(item.Key);
        }

        _currentUnsavedList.Clear();
        foreach (var item in Items)
        {
            _currentUnsavedList.Add(item, ChangeType.Unchanged);
        }

        return Task.CompletedTask;
    }

    private T GetFromUsavedList(int id)
    {
        if (!_currentUnsavedList.Any(item => item.Key.Id == id))
        {
            throw new Exception("This item doesn't exist");
        }

        return _currentUnsavedList.First(item => item.Key.Id == id).Key;
    }

    protected int GetNextIdValue()
    {
        return ++_currentIdentityValue;
    }

    public Task<List<T>> GetAllAsync()
    {
        return Task.FromResult(Items);
    }
}
