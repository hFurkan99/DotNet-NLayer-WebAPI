using System.Linq.Expressions;

namespace App.Repositories;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> GetAll();
    IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    ValueTask<T?> GetByIdAsync(int id);
    Task<PaginatedResult<T>> GetPagedAsync(int pageNumber, int pageSize);
    ValueTask AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}
