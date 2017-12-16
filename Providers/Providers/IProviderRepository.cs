using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseServer.DTO;

namespace WarehouseServer.Providers
{
  public interface IProviderRepository : IRepository<ProviderDto>
  {
    Task<IEnumerable<ProviderDto>> GetThreeTheMostValuableProviders();
  }
}
