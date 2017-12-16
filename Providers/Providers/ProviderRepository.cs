using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WarehouseServer.DTO;
using System.Linq;
using System.Collections.Generic;

namespace WarehouseServer.Providers
{
  public class ProviderRepository : Repository<ProviderDto>, IProviderRepository
  {
    public ProviderRepository(EFContext context) : base(context) { }
    public EFContext Context
    {
      get { return this.context as EFContext; }
    }

    public async Task<IEnumerable<ProviderDto>> GetThreeTheMostValuableProviders()
    {
      var result = await Context.Providers.FromSql(@"
        select providers.id, providers.name, providers.phone, providers.address, (sum(receipts.quantity) - sum(realizations.quantity)) quantity
	        from providers
	        join goods on providers.id=goods.provider_id
	        join receipts on goods.id=receipts.good_id
	        join realizations on goods.id=realizations.good_id
	        group by providers.id, providers.name
	        order by quantity desc
	        limit 3;
        ").ToListAsync();

      return result;
    }
  }
}