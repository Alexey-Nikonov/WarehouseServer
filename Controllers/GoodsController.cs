using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseServer.DTO;
using WarehouseServer.Entities;
using WarehouseServer.Providers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WarehouseServer.Controllers
{
  public class GoodsController : BaseController<Good, GoodDto>
  {
    private readonly IGoodRepository repository;
    public GoodsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
      this.repository = (IGoodRepository)this.unitOfWork.Repository<GoodDto>();
    }

    [Authorize]
    [HttpGet("GetFiveTheMostPopularGoods")]
    public async Task<IActionResult> GetFiveTheMostPopularGoods()
    {
      try
      {
        using (unitOfWork)
        {
          IEnumerable<GoodDto> resultDto = await repository.GetFiveTheMostPopularGoods();

          await unitOfWork.CompleteAsync();

          var result = mapper.Map<IEnumerable<Good>>(resultDto);
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
