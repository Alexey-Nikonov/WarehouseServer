using System;
using WarehouseServer.DTO;
using WarehouseServer.Entities;
using WarehouseServer.Providers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace WarehouseServer.Controllers
{
  public class ClientsController : BaseController<Client, ClientDto>
  {
    private readonly IClientRepository repository;
    public ClientsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
      this.repository = (IClientRepository)this.unitOfWork.Repository<ClientDto>();
    }

    [Authorize]
    [HttpGet("GetTheMostValuableCustomer")]
    public async Task<IActionResult> GetTheMostValuableCustomer()
    {
      try
      {
        using (unitOfWork)
        {
          ClientDto resultDto = await repository.GetTheMostValuableCustomer();

          if (resultDto == null)
          {
            return NotFound();
          }

          await unitOfWork.CompleteAsync();

          var result = mapper.Map<Client>(resultDto);
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