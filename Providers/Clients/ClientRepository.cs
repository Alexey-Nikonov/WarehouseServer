using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WarehouseServer.DTO;
using System.Linq;

namespace WarehouseServer.Providers
{
  public class ClientRepository : Repository<ClientDto>, IClientRepository
  {
    public ClientRepository(EFContext context) : base(context) { }

    public EFContext Context
    {
      get { return this.context as EFContext; }
    }

    public async Task<ClientDto> GetTheMostValuableCustomer()
    {
      var result = await Context.Clients.FromSql<ClientDto>(@"
        select clients.id, clients.fio, clients.address, clients.phone, sum(goods.price*realizations.quantity) as max_cost
            from clients
            inner join realizations on clients.id=realizations.client_id
            inner join goods on realizations.good_id=goods.id
            group by clients.id
            order by max_cost desc
            limit 1;
        ").ToListAsync();

      return result.FirstOrDefault();
    }
  }
}