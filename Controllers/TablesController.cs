using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseServer.DTO;
using WarehouseServer.Entities;
using WarehouseServer.Providers;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace WarehouseServer.Controllers
{
  public class TablesController: BaseController<Table, TableDto>
  {
    private readonly ITableRepository repository;
    public TablesController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
      this.repository = (ITableRepository)this.unitOfWork.Repository<TableDto>();
    }
    
    public override Task<IActionResult> Get(int id) => throw new NotImplementedException();
    public override Task<IActionResult> Post([FromBody]Table item) => throw new NotImplementedException();
    public override Task<IActionResult> Delete(int id) => throw new NotImplementedException();
    public override Task<IActionResult> Put(int id, [FromBody]Table item) => throw new NotImplementedException();
  }
}
