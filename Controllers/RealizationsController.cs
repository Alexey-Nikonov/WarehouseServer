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
  public class RealizationsController : BaseController<Realization, RealizationDto>
  {
    private readonly IRealizationRepository repository;
    public RealizationsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
      this.repository = (IRealizationRepository)this.unitOfWork.Repository<RealizationDto>();
    }
  }
}
