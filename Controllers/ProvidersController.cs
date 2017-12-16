using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseServer.DTO;
using WarehouseServer.Entities;
using WarehouseServer.Providers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WarehouseServer.Controllers
{
  public class ProvidersController : BaseController<Provider, ProviderDto>
  {
    private readonly IProviderRepository repository;
    public ProvidersController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
      this.repository = (IProviderRepository)this.unitOfWork.Repository<ProviderDto>();
    }

    [Authorize]
    [HttpGet("GetThreeTheMostValuableProviders")]
    public async Task<IActionResult> GetThreeTheMostValuableProviders()
    {
      try
      {
        using (unitOfWork)
        {
          IEnumerable<ProviderDto> resultDto = await repository.GetThreeTheMostValuableProviders();

          await unitOfWork.CompleteAsync();

          var result = mapper.Map<IEnumerable<Provider>>(resultDto);
          return Json(result);
        }
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }
    }
  }
}
