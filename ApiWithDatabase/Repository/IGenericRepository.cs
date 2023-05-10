namespace ApiWithDatabase.Repository;

using System.Linq.Expressions;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null,
       params Expression<Func<T, object>>[] includes);

    Task<T> GetByIdAsync(int id);
    Task AddAsync(T obj);
    void Update(T obj);
    void Delete(int id);
    Task SaveAsync();
}