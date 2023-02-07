using SalesAPI.Domain.Core;
using SalesAPI.Domain.Core.Entities;
using System.Linq.Expressions;

namespace SalesAPI.Domain.Interfaces;
public interface IRepository<T> where T : class
{
    IUnitOfWork UnitOfWork { get; }
    void Add(T obj);
    Task AddASync(T obj);
    void Delete(Expression<Func<T, bool>> predicate);
    Task DeleteAsync(Expression<Func<T, bool>> predicate);
    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    IEnumerable<T> GetAll();
    Task<IEnumerable<T>> GetAllAsync();
    Task<int> SaveChangesAsync();
    void Update(Expression<Func<T, bool>> expression, T obj);
    Task UpdateAsync(Expression<Func<T, bool>> expression, T obj);
}
