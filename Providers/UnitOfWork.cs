using System;
using System.Collections.Generic;
using WarehouseServer.DTO;
using System.Threading.Tasks;

namespace WarehouseServer.Providers
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly EFContext context;    
    private Dictionary<string, object> repositories;
    private bool disposed;

    public UnitOfWork(EFContext context)
    {
      this.context = context;

      this.repositories = new Dictionary<string, object>
      {
        { typeof(UserDto).Name, new UserRepository(this.context) },
        { typeof(ClientDto).Name, new ClientRepository(this.context) },
        { typeof(GoodDto).Name, new GoodRepository(this.context) },        
        { typeof(ProviderDto).Name, new ProviderRepository(this.context) },
        { typeof(RealizationDto).Name, new RealizationRepository(this.context) },
        { typeof(ReceiptDto).Name, new ReceiptRepository(this.context) },
        { typeof(TableDto).Name, new TableRepository(this.context) }
      };
    }

    public async Task<int> CompleteAsync()
    {
      return await context.SaveChangesAsync();
    }

    public IRepository<T> Repository<T>() where T : BaseModelDto
    {
      var typeName = typeof(T).Name;
      return repositories[typeName] as IRepository<T>;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (disposed) return;

      if (disposing)
      {
        context.Dispose();
      }

      disposed = true;
    }

    ~UnitOfWork()
    {
      Dispose(false);
    }
  }
}