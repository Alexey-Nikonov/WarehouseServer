using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseServer.Providers;
using System.Security.Claims;
using WarehouseServer.DTO;
using WarehouseServer.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;

namespace WarehouseServer.Controllers
{
  [Route("api/account")]
  public class AccountController : BaseController<User, UserDto>
  {
    private readonly IUserRepository repository;
    public AccountController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
      this.repository = (IUserRepository)this.unitOfWork.Repository<UserDto>();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]Login user)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      ClaimsIdentity claimsIdentity;

      try
      {
        using (unitOfWork)
        {
          var dbUser = (await repository.FindAsync(u => u.Username == user.Username && u.Password == user.Password)).SingleOrDefault();

          if (dbUser == null)
          {
            throw new Exception("Неверно введен логин или пароль");
          }

          claimsIdentity = GetClaimIdentity(dbUser.Username, dbUser.Password, dbUser.Role);
          await unitOfWork.CompleteAsync();
        }
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }

      var claims = claimsIdentity.Claims;
      var encodedJwt = GetEncodedJwtToken(claims);
      var role = GetRole(claims);

      var response = new
      {
        token = encodedJwt,
        username = claimsIdentity.Name,
        role = role
      };

      return Json(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]Register regData)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      ClaimsIdentity claimsIdentity;

      try
      {
        using (unitOfWork)
        {
          var dbUser = (await repository.FindAsync(u => u.Username == regData.Username)).SingleOrDefault();

          if (dbUser != null)
          {
            throw new Exception($"Пользователь с логином {dbUser.Username} уже существует");
          }

          claimsIdentity = GetClaimIdentity(regData.Username, regData.Password, "user");

          var newUser = new UserDto
          {
            Username = regData.Username,
            Password = regData.Password,
            Role = "user"
          };

          await repository.AddAsync(newUser);
          await unitOfWork.CompleteAsync();
        }
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }

      var claims = claimsIdentity.Claims;
      var encodedJwt = GetEncodedJwtToken(claims);
      var role = GetRole(claims);

      var response = new
      {
        token = encodedJwt,
        username = claimsIdentity.Name,
        role = role
      };

      return Json(response);
    }

    private string GetEncodedJwtToken(IEnumerable<Claim> claims)
    {
      var now = DateTime.UtcNow;

      var jwt = new JwtSecurityToken(
        issuer: AuthOptions.ISSUER,
        audience: AuthOptions.AUDIENCE,
        notBefore: now,
        claims: claims,
        expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

      var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

      return encodedJwt;
    }

    private string GetRole(IEnumerable<Claim> claims)
    {
      return claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).SingleOrDefault();
    }

    private ClaimsIdentity GetClaimIdentity(string username, string password, string role)
    {
      var claims = new List<Claim>
      {
        new Claim(ClaimsIdentity.DefaultNameClaimType, username),
        new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
      };

      var claimsIdentity = new ClaimsIdentity(
        claims,
        "Token",
        ClaimsIdentity.DefaultNameClaimType,
        ClaimsIdentity.DefaultRoleClaimType);

      return claimsIdentity;
    }

    public override Task<IActionResult> Get() => throw new NotImplementedException();
    public override Task<IActionResult> Get(int id) => throw new NotImplementedException();
    public override Task<IActionResult> Post([FromBody]User item) => throw new NotImplementedException();
    public override Task<IActionResult> Delete(int id) => throw new NotImplementedException();
    public override Task<IActionResult> Put(int id, [FromBody]User item) => throw new NotImplementedException();
  }
}