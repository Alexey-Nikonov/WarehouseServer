using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseServer.DTO;
using WarehouseServer.Entities;
using WarehouseServer.Providers;
using AutoMapper;

namespace WarehouseServer.Controllers
{
  public class ReceiptsController : BaseController<Receipt, ReceiptDto>
  {
    private readonly IReceiptRepository repository;
    public ReceiptsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
      this.repository = (IReceiptRepository)this.unitOfWork.Repository<ReceiptDto>();
    }
  }
}
