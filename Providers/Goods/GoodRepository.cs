using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WarehouseServer.DTO;
using System.Linq;
using System.Collections.Generic;

namespace WarehouseServer.Providers
{
  public class GoodRepository : Repository<GoodDto>, IGoodRepository
  {
    public GoodRepository(EFContext context) : base(context) { }
    public EFContext Context
    {
      get { return this.context as EFContext; }
    }

    public async Task<IEnumerable<GoodDto>> GetFiveTheMostPopularGoods()
    {
      var result = await Context.Goods.FromSql(@"
        select goods.id, goods.name, goods.price, goods.provider_id, (sum(receipts.quantity) - sum(realizations.quantity)) quantity
	        from receipts
	        join goods on goods.id=receipts.good_id
	        join realizations on goods.id=realizations.good_id
	        group by goods.id, goods.name
	        order by quantity desc
	        limit 5;
        ").ToListAsync();

      return result;
    }
  }
}