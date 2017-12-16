using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WarehouseServer.DTO;
using WarehouseServer.Providers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace WarehouseServer.Controllers
{
  [Route("api/[controller]")]
  public abstract class BaseController<TEntity, TDto> : Controller where TEntity : class where TDto : BaseModelDto
  {
    private readonly IRepository<TDto> repository;
    protected readonly IMapper mapper;
    protected readonly IUnitOfWork unitOfWork;

    public BaseController(IUnitOfWork unitOfWork, IMapper mapper)
    {
      this.mapper = mapper;
      this.unitOfWork = unitOfWork;      
      this.repository = this.unitOfWork.Repository<TDto>();
    }

    [Authorize]
    [HttpGet]
    public async virtual Task<IActionResult> Get()
    {
      try
      {
        using (unitOfWork)
        {
          IEnumerable<TDto> resultDto = await repository.GetAllAsync();

          await unitOfWork.CompleteAsync();

          var result = mapper.Map<IEnumerable<TEntity>>(resultDto);
          return Json(result);
        }
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }
    }

    [Authorize]
    [HttpGet("{id}")]
    public async virtual Task<IActionResult> Get(int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      try
      {
        using (unitOfWork)
        {
          TDto itemDto = await repository.GetAsync(id);

          if (itemDto == null)
          {
            return NotFound();
          }

          await unitOfWork.CompleteAsync();

          var item = mapper.Map<TEntity>(itemDto);
          return Json(item);
        }
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public async virtual Task<IActionResult> Post([FromBody]TEntity item)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      try
      {
        using (unitOfWork)
        {
          var itemDto = mapper.Map<TDto>(item);

          await repository.AddAsync(itemDto);

          await unitOfWork.CompleteAsync();
          return Json(item);
        }
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("{id}")]
    public async virtual Task<IActionResult> Delete(int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      try
      {
        TDto itemDto = await repository.GetAsync(id);
        await repository.RemoveAsync(itemDto);

        await unitOfWork.CompleteAsync();

        var item = mapper.Map<TEntity>(itemDto);
        return Json(item);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }
    }

    [Authorize(Roles = "admin")]
    [HttpPut("{id}")]
    public async virtual Task<IActionResult> Put(int id, [FromBody]TEntity item)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      try
      {
        var itemDto = mapper.Map<TDto>(item);

        if (id != itemDto.Id)
        {
          return BadRequest();
        }

        await repository.UpdateAsync(itemDto);

        await unitOfWork.CompleteAsync();
        return Json(item);
      }
      catch(DbUpdateConcurrencyException)
      {
        if (!ItemExists())
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }

      bool ItemExists()
      {
        return repository.GetAsync(id) != null;
      }
    }
  }
}