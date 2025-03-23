using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace App.Repositories;

public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : class
{
    protected AppDbContext Context = context;

    private readonly DbSet<T> _dbSet = context.Set<T>();

    public IQueryable<T> GetAll() => _dbSet.AsQueryable().AsNoTracking();

    public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).AsNoTracking();

    public ValueTask<T?> GetByIdAsync(int id) => _dbSet.FindAsync(id);

    public IQueryable<T> GetPagedAsync(int pageNumber, int pageSize)
    {
        var items = _dbSet
            .AsNoTracking()
            .AsQueryable()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        return items;
    }

    public async ValueTask AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Update(T entity) => _dbSet.Update(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);
}
