using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WarehouseServer.DTO;
using System.Threading.Tasks;

namespace WarehouseServer.Providers
{
  public class Repository<T> : IRepository<T> where T : BaseModelDto
  {
    protected readonly DbContext context;
    public Repository(DbContext context)
    {
      this.context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync() =>
      await context.Set<T>().ToListAsync();

    public async Task<T> GetAsync(int id) =>
      await context.Set<T>().FirstOrDefaultAsync(m => m.Id == id);

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) =>
      await Task.Run(() => context.Set<T>().Where(predicate));

    public async Task AddAsync(T item) =>
      await context.Set<T>().AddAsync(item);

    public async Task AddRangeAsync(IEnumerable<T> items) =>
      await context.AddRangeAsync(items);

    public async Task RemoveAsync(T item) =>
      await Task.Run(() => context.Set<T>().Remove(item));

    public async Task RemoveRangeAsync(IEnumerable<T> items) =>
      await Task.Run(() => context.Set<T>().RemoveRange(items));

    public async Task UpdateAsync(T item) =>
      await Task.Run(() => context.Entry(item).State = EntityState.Modified);

    public async Task UpdateRangeAsync(IEnumerable<T> items) =>
      await Task.Run(() => items.ToList().ForEach(item => context.Entry(item).State = EntityState.Modified));
  }
}