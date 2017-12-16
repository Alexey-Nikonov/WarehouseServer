using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using WarehouseServer.DTO;
using System.Threading.Tasks;

namespace WarehouseServer.Providers
{
  public interface IRepository<T> where T : BaseModelDto
  {
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetAsync(int id);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    Task AddAsync(T item);
    Task AddRangeAsync(IEnumerable<T> items);    

    Task RemoveAsync(T item);
    Task RemoveRangeAsync(IEnumerable<T> items);

    Task UpdateAsync(T item);
    Task UpdateRangeAsync(IEnumerable<T> items);
  }
}