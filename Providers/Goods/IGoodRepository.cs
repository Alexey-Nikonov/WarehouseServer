using WarehouseServer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WarehouseServer.Providers
{
  public interface IGoodRepository : IRepository<GoodDto>
  {
    Task<IEnumerable<GoodDto>> GetFiveTheMostPopularGoods();
  }
}