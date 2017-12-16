using System;
using WarehouseServer.DTO;
using System.Threading.Tasks;

namespace WarehouseServer.Providers
{
  public interface IUnitOfWork : IDisposable
  {
    Task<int> CompleteAsync();
    IRepository<T> Repository<T>() where T : BaseModelDto;
  }
}