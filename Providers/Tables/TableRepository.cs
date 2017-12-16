using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WarehouseServer.DTO;

namespace WarehouseServer.Providers
{
  public class TableRepository : Repository<TableDto>, ITableRepository
  {
    public TableRepository(EFContext context) : base(context) { }
    public EFContext Context
    {
      get { return this.context as EFContext; }
    }
  }
}
