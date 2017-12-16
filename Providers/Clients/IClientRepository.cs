using System.Threading.Tasks;
using WarehouseServer.DTO;

namespace WarehouseServer.Providers
{
  public interface IClientRepository : IRepository<ClientDto>
  {
    Task<ClientDto> GetTheMostValuableCustomer();
  }
}